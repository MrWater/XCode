using XCode.Module.SimplePS.Common;
using XCode.Module.SimplePS.Common.Paint;
using XCode.Module.SimplePS.Common.Style;
using XCode.Module.SimplePS.Geometry;
using XCode.Module.SimplePS.Geometry.Action;
using XCode.Module.SimplePS.Geometry.GeometrySpecialAction;
using XCode.Module.SimplePS.Geometry.Style;
using XCode.Module.SimplePS.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace XCode.Module.SimplePS.Paint.Tool
{
    /// <summary>
    /// 文本工具
    /// </summary>
    internal class TextTool : PaintToolBase
    {
        private Brush _foreground;

        #region 样式属性
        /// <summary>
        /// 文本颜色
        /// </summary>
        [Style(DisplayName = "文字颜色")]
        public Brush Foreground
        {
            get { return _foreground; }
            set
            {
                if (_foreground == value)
                    return;

                _foreground = value;
                RaisePropertyChanged("Foreground");
            }
        }

        private System.Drawing.Font _font;
        /// <summary>
        /// 字体
        /// </summary>
        [Style(DisplayName = "字体", Editable = false)]
        public System.Drawing.Font Font
        {
            get { return _font; }
            set
            {
                if (_font == value)
                    return;

                _font = value;
                RaisePropertyChanged("Font");
            }
        } 
        #endregion

        public TextTool()
        {
            Foreground = Brushes.Black;
            System.Drawing.Font font = new System.Drawing.Font("宋体", 50);
            Font = new System.Drawing.Font(font, System.Drawing.FontStyle.Regular);
        }
        /// <summary>
        /// 通知图层列表响应
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        private void NotifyLayerGroup(PaintContext context, PaintResult result)
        {
            if (result.PaintLayerType == PaintLayerType.New)
            {
                foreach (var layer in result.Layers)
                {
                    layer.Name = "未命名" + context.HistoryLayerCnt++.ToString();
                    context.LayerGroup.Insert(0, layer);

                    var geometrys = layer.GetGeometries();
                    if (geometrys != null)
                    {
                        geometrys.ForEach(m => context.Canvas.AddChild(m));
                    }
                }
            }
        }

        public override PaintResult BeginPaint(PaintContext context, Point beginPoint)
        {
            if (context == null)
                return null;

            if (_layers == null)
                _layers = new List<LayerBase>();
            else
                _layers.Clear();

            _paintContext = context;
            PaintResult result = new PaintResult();
            result.PaintLayerType = PaintLayerType.New;
            
            SimpleLayer layer = new SimpleLayer();
            _geometry = new Text(new TextStyle()
            {
                FirstPoint = beginPoint,
                SecondPoint = beginPoint,
                Font = (context.PaintTool as TextTool).Font,
                Foreground = (context.PaintTool as TextTool).Foreground,
            }, new TextAction());

            layer.AddGeometry(_geometry);
            _layers.Add(layer);
            result.Layers = _layers;

            context.OperationLayers.Clear();
            _layers.ForEach(m => context.OperationLayers.Add(m));

            NotifyLayerGroup(context, result);

            return result;
        }

        public override void Paint(Point currentPoint)
        {
            _geometry.Style.SecondPoint = currentPoint;
            _geometry.SpecialActionGroup.Clear();
            _geometry.SpecialActionGroup.AddRange(SpecialActionPool.Default[typeof(Line)]);
            _geometry.Refresh();
        }

        public override void EndPaint()
        {
            _geometry.SpecialActionGroup.Clear();

            if (_paintContext != null && _paintContext.OperationLayers != null)
            {
                for (int i = 0; i < _paintContext.OperationLayers.Count; ++i)
                {
                    _paintContext.OperationLayers[i].Refresh();
                }
            }
        }
    }
}
