using XCode.Module.SimplePS.Action;
using XCode.Module.SimplePS.Common;
using XCode.Module.SimplePS.Common.Style;
using XCode.Module.SimplePS.Geometry.GeometryStyle;
using XCode.Module.SimplePS.Layer;
using XCode.Module.SimplePS.Service;
using XCode.Module.SimplePS.PaintTool;
using XCode.Module.SimplePS.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XCode.Module.SimplePS.Common.Paint;

namespace XCode.Module.SimplePS.View
{
    /// <summary>
    /// TemplateEditView.xaml 的交互逻辑
    /// </summary>
    public partial class TemplateEditView : UserControl
    {
        private bool _leftButtonPressed;
        private List<LayerBase> _oldSelectedLayers;

        internal TemplateEditService Service
        {
            get
            {
                return (DataContext as TemplateEditViewModel).Service;
            }
        }

        public TemplateEditView()
        {
            InitializeComponent();

            Container.MouseLeftButtonDown += Container_MouseLeftButtonDown;
            Container.MouseMove += Container_MouseMove;
            Container.MouseLeftButtonUp += Container_MouseLeftButtonUp;

            Service.PaintContext.Canvas = CvsRoot;
            LayerList.ItemsSource = Service.LayerList;
            _oldSelectedLayers = new List<LayerBase>();
        }

        private void Container_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(_leftButtonPressed)
            {
                PaintManager.EndPaint();
                CvsRoot.ClipToBounds = true;
            }

            _leftButtonPressed = false;
        }

        private void Container_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = e.GetPosition(CvsRoot);

            if (_leftButtonPressed)
            {
                PaintManager.Paint(pt);
            }

            CoordX.Text = pt.X.ToString();
            CoordY.Text = pt.Y.ToString();
        }

        private void Container_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Service.PaintContext.ToolType == ToolType.None)
                return;
            
            CvsRoot.ClipToBounds = false;
            _leftButtonPressed = true;
            PaintResult result = PaintManager.BeginPaint(Service.PaintContext, e.GetPosition(CvsRoot));
           
            if(result.PaintLayerType == PaintLayerType.New)
            {
                foreach(var layer in result.Layers)
                {
                    layer.Name = "未命名" + Service.LayerList.Count.ToString();
                    Service.AddLayer(layer);
                }
            }
        }

        public void ToolSeletedChanged(object sender, EventArgs e)
        {
            var uid = (sender as RadioButton).Uid;
            Service.PaintContext.Update(uid);
            Container.Cursor = Service.PaintContext.Cursor;

            if(Service.PaintContext.PaintTool != null)
            {
                PaintTool.Child = Service.PaintContext.PaintTool.GetEditorPanel(Orientation.Horizontal);
            }
            else
            {
                PaintTool.Child = null;
            }
        }

        private void LayerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Service.PaintContext.Update(LayerList.SelectedItems);

            foreach(var item in _oldSelectedLayers)
            {
                foreach(var Geometry in item.GetGeometrys())
                {
                    Geometry.Style.HighLight = false;
                }

                item.Refresh();
            }

            _oldSelectedLayers.Clear();

            if(LayerList.SelectedItems.Count == 1)
            {
                LayerBase layer = LayerList.SelectedItems[0] as LayerBase;
                var Geometrys = layer.GetGeometrys();

                if(Geometrys != null && Geometrys.Count == 1)
                {
                    TabItemGeometryProperty.Content = Geometrys[0].Style.GetEditorPanel();
                }
                else
                {
                    TabItemGeometryProperty.Content = null;
                }
            }
            else
            {
                TabItemGeometryProperty.Content = null;
            }

            foreach(var item in LayerList.SelectedItems)
            {
                LayerBase layer = item as LayerBase;
                _oldSelectedLayers.Add(layer);
                layer.HighLight();
            }
        }

        /// <summary>
        /// 绑定command删除多个会出问题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveLayer_Click(object sender, RoutedEventArgs e)
        {
            List<LayerBase> list = new List<LayerBase>();
            
            foreach(var item in LayerList.SelectedItems)
            {
                list.Add(item as LayerBase);
            }

            LayerList.UnselectAll();
            Service.RemoveLayer(list);
        }
    }
}
