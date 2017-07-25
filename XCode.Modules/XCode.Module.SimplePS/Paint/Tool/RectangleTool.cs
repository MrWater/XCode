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
using System.Windows.Media;

namespace XCode.Module.SimplePS.Paint.Tool
{
    /// <summary>
    /// 矩形工具
    /// </summary>
    internal class RectangleTool : PaintToolBase, IFillStyle
    {
        #region 样式属性
        private Brush _lineBrush;
        /// <summary>
        /// 直线颜色
        /// </summary>
        [Style(DisplayName = "线色")]
        public Brush LineBrush
        {
            get { return _lineBrush; }
            set
            {
                if (_lineBrush == value)
                    return;

                _lineBrush = value;
                RaisePropertyChanged("LineBrush");
            }
        }

        private double _lineWidth;
        /// <summary>
        /// 线条宽度
        /// </summary>
        [Style(DisplayName = "线度", Measure = "像素")]
        public double LineWidth
        {
            get { return _lineWidth; }
            set
            {
                if (_lineWidth == value)
                    return;

                _lineWidth = value;
                RaisePropertyChanged("LineWidth");
            }
        }

        private Brush _fillBrush;
        /// <summary>
        /// 填充颜色
        /// </summary>
        [Style(DisplayName = "填充色")]
        public Brush FillBrush
        {
            get { return _fillBrush; }
            set
            {
                if (_fillBrush == value)
                    return;

                _fillBrush = value;
                RaisePropertyChanged("FillBrush");
            }
        } 
        #endregion

        public RectangleTool()
        {
            LineBrush = Brushes.Black;
            FillBrush = Brushes.Black;
            LineWidth = 1;
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
            _geometry = null;
            SimpleLayer layer = new SimpleLayer();
            PaintResult result = new PaintResult();
            result.PaintLayerType = PaintLayerType.New;
            _geometry = new Rectangle(new RectangleStyle()
            {
                FirstPoint = beginPoint,
                SecondPoint = beginPoint,
                LineBrush = (context.PaintTool as RectangleTool).LineBrush,
                FillBrush = (context.PaintTool as RectangleTool).FillBrush,
                LineWidth = (context.PaintTool as RectangleTool).LineWidth
            }, new RectangleAction());

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
            _geometry.SpecialActionGroup.AddRange(SpecialActionPool.Default[typeof(Rectangle)]);
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
