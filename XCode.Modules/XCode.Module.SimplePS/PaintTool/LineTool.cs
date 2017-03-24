using XCode.Module.SimplePS.Common;
using XCode.Module.SimplePS.Common.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace XCode.Module.SimplePS.PaintTool
{
    /// <summary>
    /// 直线工具
    /// </summary>
    internal class LineTool : PaintToolBase
    {
        private Brush _lineBrush;
        /// <summary>
        /// 直线颜色
        /// </summary>
        [Style(DisplayName = "颜色")]
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
        [Style(DisplayName = "宽度", Measure = "像素")]
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

        public LineTool()
        {
            LineBrush = Brushes.Black;
            LineWidth = 1;
        }
    }
}
