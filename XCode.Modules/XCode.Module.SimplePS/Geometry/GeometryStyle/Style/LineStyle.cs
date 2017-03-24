using XCode.Module.SimplePS.Common;
using XCode.Module.SimplePS.Common.Style;
using XCode.Module.SimplePS.Geometry.GeometryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace XCode.Module.SimplePS.Geometry.GeometryStyle.Style
{
    /// <summary>
    /// 线条样式
    /// </summary>
    internal class LineStyle : GeometryStyleBase
    {
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

        private Brush _lineBrush;
        /// <summary>
        /// 线条颜色
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

        public LineStyle()
            : base()
        {
            LineWidth = 1;
            LineBrush = Brushes.Black;
            DashStyle = DashStyles.Solid;
        }
    }
}
