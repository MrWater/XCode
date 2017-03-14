using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace XCode.Common.Controls.TabControls
{
    public class XImgTabControl : TabControl
    {
        static XImgTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(XImgTabControl), new FrameworkPropertyMetadata(typeof(XImgTabControl)));
        }

        public static readonly DependencyProperty TextVisibleProperty = DependencyProperty.Register(
            "TextVisible", typeof(bool), typeof(XImgTabControl), new PropertyMetadata(true));
        //public static readonly DependencyProperty HeadImgSourceProperty = DependencyProperty.Register(
        //    "HeadImgSource", typeof(ImageSource), typeof(XImgTabControl), new PropertyMetadata(new BitmapImage(new Uri("/Images/1.png", UriKind.Relative))));

        public bool TextVisible
        {
            get { return (bool)GetValue(TextVisibleProperty); }
            set { SetValue(TextVisibleProperty, value); }
        }

        //public ImageSource HeadImgSource
        //{
        //    get { return (ImageSource)GetValue(HeadImgSourceProperty); }
        //    set { SetValue(HeadImgSourceProperty, value); }
        //}
    }
}
