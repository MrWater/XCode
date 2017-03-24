using XCode.Module.SimplePS.Common;
using XCode.Module.SimplePS.Common.Style;
using XCode.Module.SimplePS.Geometry.GeometryStyle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace XCode.Module.SimplePS.Geometry.GeometryProperty
{
    /// <summary>
    /// Geometry样式
    /// </summary>
    internal abstract class GeometryStyleBase : ObservableObject, ICloneable, IStyle
    {
        //private double _left;
        ///// <summary>
        ///// 位置Left
        ///// </summary>
        //[Style(DisplayName = "位置—X")]
        //public double Left
        //{
        //    get { return _left; }
        //    set
        //    {
        //        if (_left == value)
        //            return;

        //        RaisePropertyChanged("Left");
        //    }
        //}

        //private double _top;
        ///// <summary>
        ///// 位置Top
        ///// </summary>
        //[Style(DisplayName = "位置—Y")]
        //public double Top
        //{
        //    get { return _top; }
        //    set
        //    {
        //        if (_top == value)
        //            return;

        //        RaisePropertyChanged("Top");
        //    }
        //}

        //private double _width;
        ///// <summary>
        ///// 宽度
        ///// </summary>
        //[Style(DisplayName = "宽度")]
        //public double Width
        //{
        //    get { return _width; }
        //    set
        //    {
        //        if (_width == value)
        //            return;

        //        RaisePropertyChanged("Width");
        //    }
        //}

        //private double _height;
        ///// <summary>
        ///// 高度
        ///// </summary>
        //[Style(DisplayName = "高度")]
        //public double Height
        //{
        //    get { return _height; }
        //    set
        //    {
        //        if (_height == value)
        //            return;

        //        RaisePropertyChanged("Height");
        //    }
        //}

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
                RaisePropertyChanged("SecondPoint");
            }
        }

        public bool HighLight { get; set; }

        protected GeometryStyleBase()
        {
            HighLight = false;
        }

        public object Clone()
        {
            return this.DeepCopy();
        }
    }
}
