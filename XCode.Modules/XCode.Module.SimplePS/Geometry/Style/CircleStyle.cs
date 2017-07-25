using XCode.Module.SimplePS.Common.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace XCode.Module.SimplePS.Geometry.Style
{
    /// <summary>
    /// 圆形样式
    /// </summary>
    internal class CircleStyle : GeometryStyleBase, IFillStyle
    {
        private double _lineWidth;
        /// <summary>
        /// 线条宽度
        /// </summary>
        [Style(DisplayName = "线宽", Measure = "像素")]
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

        public CircleStyle()
            : base()
        {
            LineWidth = 1;
            LineBrush = Brushes.Black;
            FillBrush = Brushes.Black;
            DashStyle = DashStyles.Solid;
        }
    }
}
