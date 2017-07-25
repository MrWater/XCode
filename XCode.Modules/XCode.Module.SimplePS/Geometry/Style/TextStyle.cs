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
    /// 文本样式
    /// </summary>
    internal class TextStyle : GeometryStyleBase
    {
        private Brush _foreground;
        /// <summary>
        /// 文本颜色
        /// </summary>
        [Style(DisplayName = "文字颜色")]
        public Brush Foreground
        {
            get { return _foreground; }
            set
            {
                if (_foreground == value)
                    return;

                _foreground = value;
                RaisePropertyChanged("Foreground");
            }
        }

        private string _text;
        /// <summary>
        /// 文本
        /// </summary>
        [Style(DisplayName = "文本", ToolTip = "支持回车换行显示")]
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text == value)
                    return;

                _text = value;
                RaisePropertyChanged("Text");
            }
        }

        private System.Drawing.Font _font;
        /// <summary>
        /// 字体
        /// </summary>
        [Style(DisplayName = "字体", Editable = false)]
        public System.Drawing.Font Font
        {
            get { return _font; }
            set
            {
                if (_font == value)
                    return;

                _font = value;
                RaisePropertyChanged("Font");
            }
        }

        public TextStyle()
            : base()
        {
            Foreground = Brushes.Black;
            System.Drawing.Font font = new System.Drawing.Font("宋体", 50);
            Font = new System.Drawing.Font(font, System.Drawing.FontStyle.Regular);
            Text = "示例文本";
        }
    }
}
