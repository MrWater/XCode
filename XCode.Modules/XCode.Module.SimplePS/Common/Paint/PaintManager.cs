using XCode.Module.SimplePS.Geometry;
using XCode.Module.SimplePS.Geometry.GeometryAction.Action;
using XCode.Module.SimplePS.Geometry.GeometryStyle.Style;
using XCode.Module.SimplePS.Layer;
using XCode.Module.SimplePS.PaintTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace XCode.Module.SimplePS.Common.Paint
{
    /// <summary>
    /// 绘制工具
    /// </summary>
    internal class PaintManager
    {
        private static GeometryBase _Geometry;
        private static List<LayerBase> _layers;
        private static ToolType _toolType;
        private static PaintContext _paintContext;

        /// <summary>
        /// 开始执行绘制初始化
        /// </summary>
        /// <param name="GeometryType"></param>
        /// <param name="beginPoint"></param>
        /// <returns></returns>
        public static PaintResult BeginPaint(PaintContext context, Point beginPoint)
        {
            if (context == null)
                return null;

            if (_layers == null)
                _layers = new List<LayerBase>();
            else
                _layers.Clear();

            _paintContext = context;
            _Geometry = null;
            _toolType = context.ToolType;
            PaintResult result = new PaintResult();

            switch (_toolType)
            {
                case ToolType.Line:
                    {
                        SimpleLayer layer = new SimpleLayer();
                        result.PaintLayerType = PaintLayerType.New;
                        _Geometry = new Line(new LineStyle()
                        {
                            FirstPoint = beginPoint,
                            SecondPoint = beginPoint,
                            LineBrush = (context.PaintTool as LineTool).LineBrush,
                            LineWidth = (context.PaintTool as LineTool).LineWidth
                        }, new LineAction());

                        layer.AddGeometry(_Geometry);
                        _layers.Add(layer);
                    }
                    break;
                case ToolType.Drag:
                    (context.PaintTool as DragTool).StartDrag(beginPoint);
                    _layers.AddRange(context.OperationLayers);
                    result.PaintLayerType = PaintLayerType.Original;
                    break;
                default:
                    break;
            }

            result.Layers = _layers;
            return result;
        }

        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="currentPoint"></param>
        public static void Paint(Point currentPoint)
        {
            switch(_toolType)
            {
                case ToolType.Drag:
                    (_paintContext.PaintTool as DragTool).EndDrag(currentPoint);
                    _layers.ForEach(m =>
                    {
                        m.Move((_paintContext.PaintTool as DragTool).OffsetX, (_paintContext.PaintTool as DragTool).OffsetY);
                    });
                    break;
                case ToolType.Line:
                    _Geometry.Style.SecondPoint = currentPoint;
                    _layers.ForEach(m => m.Refresh());
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 结束绘制
        /// </summary>
        public static void EndPaint()
        {
            switch (_toolType)
            {
                case ToolType.Drag:
                    _layers.ForEach(m =>
                    {
                        m.Move((_paintContext.PaintTool as DragTool).OffsetX, (_paintContext.PaintTool as DragTool).OffsetY, true);
                    });
                    break;
                case ToolType.Line:
                    break;
                default:
                    break;
            }

            _layers.ForEach(m => m.Refresh());
        }
    }
}
