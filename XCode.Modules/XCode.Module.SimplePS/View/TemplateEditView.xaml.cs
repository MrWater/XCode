using XCode.Module.SimplePS.Action;
using XCode.Module.SimplePS.Common;
using XCode.Module.SimplePS.Common.Style;
using XCode.Module.SimplePS.Layer;
using XCode.Module.SimplePS.Service;
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
using System.Windows.Interop;
using XCode.Module.SimplePS.Paint.Tool;

namespace XCode.Module.SimplePS.View
{
    /// <summary>
    /// TemplateEditView.xaml 的交互逻辑
    /// </summary>
    public partial class TemplateEditView : UserControl
    {
        private bool _leftButtonPressed;
        private List<LayerBase> _oldSelectedLayers;
        private Dictionary<int, System.Action> _shortcuts;
        private bool _shiftPressed;

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
            InitEvent();
            InitShortCuts();

            Service.PaintContext.Canvas = CvsRoot;
            LayerGroup.ItemsSource = Service.PaintContext.LayerGroup;

            Binding bind = new Binding();
            bind.Source = Service.PaintContext.OperationLayers;
            
            _oldSelectedLayers = new List<LayerBase>();
            
            Keyboard.ClearFocus();
            Keyboard.Focus(CvsRoot);
        }

        //TODO: 分离快捷键和窗口过程部分
        private void InitShortCuts()
        {
            _shortcuts = new Dictionary<int, System.Action>();
            _shortcuts[(int)WindowConst.VKeys.V] = () => { RBDrag.IsChecked = true; };
            _shortcuts[(int)WindowConst.VKeys.R] = () => { RBRectangle.IsChecked = true; };
            _shortcuts[(int)WindowConst.VKeys.T] = () => { RBTriangle.IsChecked = true; };
            _shortcuts[(int)WindowConst.VKeys.C] = () => { RBCircle.IsChecked = true; };
            _shortcuts[(int)WindowConst.VKeys.L] = () => { RBLine.IsChecked = true; };
            _shortcuts[(int)WindowConst.VKeys.I] = () => { RBImage.IsChecked = true; };
            _shortcuts[(int)WindowConst.VKeys.W] = () => { RBText.IsChecked = true; };
            _shortcuts[(int)WindowConst.VKeys.Q] = () => { RBQRCode.IsChecked = true; };
        }

        private void InitEvent()
        {
            Container.MouseLeftButtonDown += Container_MouseLeftButtonDown;
            Container.MouseMove += Container_MouseMove;
            Container.MouseLeftButtonUp += Container_MouseLeftButtonUp;

            this.Loaded += TemplateEditView_Loaded;
        }

        private void TemplateEditView_Loaded(object sender, RoutedEventArgs e)
        {
            HwndSource hs = (HwndSource)PresentationSource.FromVisual(this);

            if(hs != null)
                hs.AddHook(WndProc);
        }

        private IntPtr WndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case WindowConst.WM_KEYDOWN:
                    {
                        switch (wParam.ToInt32())
                        {
                            case (int)WindowConst.VKeys.VK_SHIFT:
                                if (!_shiftPressed)
                                {
                                    _shiftPressed = true;

                                    if(Service.PaintContext.ToolType != ToolType.Drag)
                                    {
                                        Service.RegisterShiftPressedAction();
                                    }
                                }
                                break;

                            case (int)WindowConst.VKeys.VK_LEFT:
                                PaintManager.Default.MoveLeft(Service.PaintContext, 1);
                                break;
                            case (int)WindowConst.VKeys.VK_RIGHT:
                                PaintManager.Default.MoveRight(Service.PaintContext, 1);
                                break;
                            case (int)WindowConst.VKeys.VK_UP:
                                PaintManager.Default.MoveUp(Service.PaintContext, 1);
                                break;
                            case (int)WindowConst.VKeys.VK_DOWN:
                                PaintManager.Default.MoveDown(Service.PaintContext, 1);
                                break;
                                
                            case (int)WindowConst.VKeys.V:
                            case (int)WindowConst.VKeys.R:
                            case (int)WindowConst.VKeys.T:
                            case (int)WindowConst.VKeys.C:
                            case (int)WindowConst.VKeys.L:
                            case (int)WindowConst.VKeys.I:
                            case (int)WindowConst.VKeys.W:
                            case (int)WindowConst.VKeys.Q:
                                if (_shortcuts.ContainsKey(wParam.ToInt32()))
                                {
                                    _shortcuts[wParam.ToInt32()]();
                                }
                                break;
                        }
                    }

                    break;

                case WindowConst.WM_KEYUP:
                    {
                        switch (wParam.ToInt32())
                        {
                            case (int)WindowConst.VKeys.VK_SHIFT:
                                _shiftPressed = false;
                                Service.UnregisterShiftPressedAction();
                                break;
                        }
                    }
                    break;

                default:
                    break;
            }

            return IntPtr.Zero;
        }

        private void Container_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(_leftButtonPressed)
            {
                PaintManager.Default.EndPaint();
                CvsRoot.ClipToBounds = true;
            }

            _leftButtonPressed = false;

            if (Service.PaintContext.ToolType != ToolType.Drag && LayerGroup.SelectedIndex != 0)
            {
                LayerGroup.SelectedIndex = 0;
            }
        }

        private void Container_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = e.GetPosition(CvsRoot);

            if (_leftButtonPressed)
            {
                PaintManager.Default.Paint(pt);
            }

            CoordX.Text = pt.X.ToString("0");
            CoordY.Text = pt.Y.ToString("0");
        }

        private void Container_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Service.PaintContext.ToolType == ToolType.None)
                return;
            
            CvsRoot.ClipToBounds = false;
            _leftButtonPressed = true;
            PaintResult result = PaintManager.Default.BeginPaint(Service.PaintContext, e.GetPosition(CvsRoot));

            if(result.PaintLayerType == PaintLayerType.New)
            {
                LayerGroup.SelectedIndex = 0;
            }

            Keyboard.ClearFocus();
            Keyboard.Focus(CvsRoot);
        }

        public void ToolSeletedChanged(object sender, EventArgs e)
        {
            var uid = (sender as RadioButton).Uid;
            Service.PaintContext.Update(uid);
            Container.Cursor = Service.PaintContext.Cursor;

            if (Service.PaintContext.PaintTool != null)
            {
                PaintTool.Child = Service.PaintContext.PaintTool.GetEditorPanel(Orientation.Horizontal);
            }
            else
            {
                PaintTool.Child = null;
            }

            Keyboard.ClearFocus();
            Keyboard.Focus(CvsRoot);
        }

        private void LayerGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Service.PaintContext.Update(LayerGroup.SelectedItems);
            CvsRoot.ContextMenu = Service.GetContextMenu();

            foreach(var item in _oldSelectedLayers)
            {
                foreach(var Geometry in item.GetGeometries())
                {
                    Geometry.Style.Highlight = false;
                }

                item.Refresh();
            }

            _oldSelectedLayers.Clear();

            if(LayerGroup.SelectedItems.Count == 1)
            {
                LayerBase layer = LayerGroup.SelectedItems[0] as LayerBase;
                var Geometrys = layer.GetGeometries();

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

            foreach(var item in LayerGroup.SelectedItems)
            {
                LayerBase layer = item as LayerBase;
                _oldSelectedLayers.Add(layer);
                layer.Highlight();
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
            
            foreach(var item in LayerGroup.SelectedItems)
            {
                list.Add(item as LayerBase);
            }

            LayerGroup.UnselectAll();
            Service.RemoveLayer(list);
        }
    }
}
