using XCode.Module.SimplePS.Common.Paint;
using XCode.Module.SimplePS.Geometry;
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
    /// 拖动工具
    /// </summary>
    internal class DragTool : PaintToolBase
    {
        private Point _startPoint;
        private Point _endPoint;

        #region 样式属性
        /// <summary>
        /// x偏移量
        /// </summary>
        public double OffsetX
        {
            get { return _endPoint.X - _startPoint.X; }
        }

        public double OffsetY
        {
            get { return _endPoint.Y - _startPoint.Y; }
        }
        #endregion
        
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

            StartDrag(beginPoint);
            _layers.AddRange(context.OperationLayers);

            PaintResult result = new PaintResult();
            result.PaintLayerType = PaintLayerType.Original;
            result.Layers = _layers;

            context.OperationLayers.Clear();
            _layers.ForEach(m => context.OperationLayers.Add(m));

            NotifyLayerGroup(context, result);

            return result;
        }

        public override void Paint(Point currentPoint)
        {
            EndDrag(currentPoint);
            _layers.ForEach(m =>
            {
                m.Move((_paintContext.PaintTool as DragTool).OffsetX, (_paintContext.PaintTool as DragTool).OffsetY);
            });
        }

        public override void EndPaint()
        {
            _layers.ForEach(m =>
            {
                m.ResetState();
            });

            if (_paintContext != null && _paintContext.OperationLayers != null)
            {
                for (int i = 0; i < _paintContext.OperationLayers.Count; ++i)
                {
                    _paintContext.OperationLayers[i].Refresh();
                }
            }
        }

        /// <summary>
        /// 开始拖动
        /// </summary>
        /// <param name="startPoint"></param>
        private void StartDrag(Point startPoint)
        {
            _startPoint = startPoint;
            _endPoint = startPoint;
        }

        /// <summary>
        /// 结束拖动
        /// </summary>
        /// <param name="endPoint"></param>
        private void EndDrag(Point endPoint)
        {
            _endPoint = endPoint;
        }
    }
}
