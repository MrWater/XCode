using XCode.Module.SimplePS.Common;
using XCode.Module.SimplePS.Common.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace XCode.Module.SimplePS.Geometry.Style
{
    /// <summary>
    /// Geometry样式
    /// </summary>
    internal abstract class GeometryStyleBase : ObservableObject, IGeometryStyle
    {
        private Point _firstPoint;
        /// <summary>
        /// 控制点1
        /// </summary>
        [Style(DisplayName = "控制点1")]
        public Point FirstPoint
        {
            get { return _firstPoint; }
            set
            {
                if (_firstPoint == value)
                    return;

                _firstPoint = value;
                Width = Math.Abs(FirstPoint.X - SecondPoint.X);
                Height = Math.Abs(FirstPoint.Y - SecondPoint.Y);
                RaisePropertyChanged("FirstPoint");
            }
        }

        private Point _secondPoint;
        /// <summary>
        /// 控制点2
        /// </summary>
        [Style(DisplayName = "控制点2")]
        public Point SecondPoint
        {
            get { return _secondPoint; }
            set
            {
                if (_secondPoint == value)
                    return;

                _secondPoint = value;
                Width = Math.Abs(FirstPoint.X - SecondPoint.X);
                Height = Math.Abs(FirstPoint.Y - SecondPoint.Y);
                RaisePropertyChanged("SecondPoint");
            }
        }

        private double _width;
        /// <summary>
        /// 宽度
        /// </summary>
        [Style(DisplayName = "宽度", Editable = false, Measure = "像素")]
        public double Width
        {
            get { return _width; }
            set
            {
                if (_width == value)
                    return;

                _width = value;
                RaisePropertyChanged("Width");
            }
        }

        private double _height;
        /// <summary>
        /// 高度
        /// </summary>
        [Style(DisplayName = "高度", Editable = false, Measure = "像素")]
        public double Height
        {
            get { return _height; }
            set
            {
                if (_height == value)
                    return;

                _height = value;
                RaisePropertyChanged("Height");
            }
        }

        /// <summary>
        /// 是否高亮显示
        /// </summary>
        public bool Highlight { get; set; }

        protected GeometryStyleBase()
        {
            Highlight = false;
        }
    }
}
