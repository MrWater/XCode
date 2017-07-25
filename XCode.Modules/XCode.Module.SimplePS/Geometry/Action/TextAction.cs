
using XCode.Module.SimplePS.Geometry.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace XCode.Module.SimplePS.Geometry.Action
{
    /// <summary>
    /// 文本Action
    /// </summary>
    internal class TextAction : GeometryActionBase
    {
        private static Pen _pen;

        static TextAction()
        {
            _pen = new Pen(Brushes.Black, 2);
            _pen.DashStyle = new DashStyle(new double[] { 5, 5 }, 5);

            if (_pen.CanFreeze)
            {
                _pen.Freeze();
            }
        }

        public override void Highlight(DrawingContext dc, GeometryStyleBase geometryStyle)
        {
            if (null == dc || !(geometryStyle is TextStyle))
                return;

            TextStyle style = geometryStyle as TextStyle;

            if (style.Font == null)
                return;

            FontFamily fontFamily = new FontFamily(style.Font.FontFamily.Name);

            if (!_moving)
            {
                _beforeMoveFirstPoint = geometryStyle.FirstPoint;
                _beforeMoveSecondPoint = geometryStyle.SecondPoint;
            }
            
            if (style.Text == null)
            {
                dc.DrawRectangle(Brushes.Transparent, _pen, new Rect(geometryStyle.FirstPoint, geometryStyle.SecondPoint));
            }
            else
            {
                dc.DrawText(new FormattedText(style.Text, new System.Globalization.CultureInfo("zh-cn"), FlowDirection.LeftToRight,
                    new Typeface(fontFamily, style.Font.Italic ? FontStyles.Italic : FontStyles.Normal, FontWeights.Normal, FontStretches.Normal), 
                    style.Font.Size, style.Foreground), geometryStyle.FirstPoint);
            }
        }

        public override void Render(DrawingContext dc, GeometryStyleBase geometryStyle)
        {
            if (null == dc || !(geometryStyle is TextStyle))
                return;

            TextStyle style = geometryStyle as TextStyle;

            if (style.Font == null)
                return;

            FontFamily fontFamily = new FontFamily(style.Font.FontFamily.Name);

            if (!_moving)
            {
                _beforeMoveFirstPoint = geometryStyle.FirstPoint;
                _beforeMoveSecondPoint = geometryStyle.SecondPoint;
            }

            if (style.Text == null)
            {
                dc.DrawRectangle(Brushes.Transparent, _pen, new Rect(geometryStyle.FirstPoint, geometryStyle.SecondPoint));
            }
            else
            {
                dc.DrawText(new FormattedText(style.Text, new System.Globalization.CultureInfo("zh-cn"), FlowDirection.LeftToRight,
                    new Typeface(fontFamily, style.Font.Italic ? FontStyles.Italic : FontStyles.Normal, FontWeights.Normal, FontStretches.Normal),
                    style.Font.Size, style.Foreground), geometryStyle.FirstPoint);
            }
        }
    }
}
