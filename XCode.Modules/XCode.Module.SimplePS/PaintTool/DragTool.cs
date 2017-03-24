using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XCode.Module.SimplePS.PaintTool
{
    /// <summary>
    /// 拖动工具
    /// </summary>
    internal class DragTool : PaintToolBase
    {
        private Point _startPoint;
        private Point _endPoint;
        
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

        /// <summary>
        /// 开始拖动
        /// </summary>
        /// <param name="startPoint"></param>
        public void StartDrag(Point startPoint)
        {
            _startPoint = startPoint;
            _endPoint = startPoint;
        }

        /// <summary>
        /// 结束拖动
        /// </summary>
        /// <param name="endPoint"></param>
        public void EndDrag(Point endPoint)
        {
            _endPoint = endPoint;
        }
    }
}
