using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace XCode.Common.Controls.Buttons
{
    public class XImgButton : Button
    {
        static XImgButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(XImgButton), new FrameworkPropertyMetadata(typeof(XImgButton)));
        }

        public static readonly DependencyProperty ImgSourceProperty = DependencyProperty.Register(
            "ImgSource", typeof(ImageSource), typeof(XImgButton), new PropertyMetadata());

        public ImageSource ImgSource
        {
            get { return (ImageSource)GetValue(ImgSourceProperty); }
            set { SetValue(ImgSourceProperty, value); }
        }
    }
}
