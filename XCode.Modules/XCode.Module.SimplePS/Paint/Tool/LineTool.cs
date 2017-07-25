using XCode.Module.SimplePS.Common;
using XCode.Module.SimplePS.Common.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using XCode.Module.SimplePS.Common.Paint;
using System.Windows;
using XCode.Module.SimplePS.Layer;
using XCode.Module.SimplePS.Geometry;
using XCode.Module.SimplePS.Geometry.Style;
using XCode.Module.SimplePS.Geometry.Action;
using XCode.Module.SimplePS.Geometry.GeometrySpecialAction;

namespace XCode.Module.SimplePS.Paint.Tool
{
    /// <summary>
    /// 直线工具
    /// </summary>
    internal class LineTool : PaintToolBase, ILineStyle
    {
        #region 样式属性
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

        private Brush _lineBrush;
        /// <summary>
        /// 线条颜色
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

        private DashStyle _dashStyle;
        /// <summary>
        /// 线条样式
        /// </summary>
        [Style(DisplayName = "线条样式")]
        public DashStyle DashStyle
        {
            get { return _dashStyle; }
            set
            {
                if (_dashStyle == value)
                    return;

                _dashStyle = value;
                RaisePropertyChanged("DashStyle");
            }
        } 
        #endregion

        public LineTool()
        {
            LineBrush = Brushes.Black;
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
            PaintResult result = new PaintResult();
            SimpleLayer layer = new SimpleLayer();
            result.PaintLayerType = PaintLayerType.New;

            _geometry = new Line(new LineStyle()
            {
                FirstPoint = beginPoint,
                SecondPoint = beginPoint,
                LineBrush = (context.PaintTool as LineTool).LineBrush,
                LineWidth = (context.PaintTool as LineTool).LineWidth
            }, new LineAction());

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
