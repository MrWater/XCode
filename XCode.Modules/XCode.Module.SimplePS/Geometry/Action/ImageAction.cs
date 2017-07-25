
using XCode.Module.SimplePS.Geometry.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace XCode.Module.SimplePS.Geometry.Action
{
    /// <summary>
    /// 图片Action
    /// </summary>
    internal class ImageAction : GeometryActionBase
    {
        private static Pen _pen;

        static ImageAction()
        {
            _pen = new Pen(Brushes.Black, 2);
            _pen.DashStyle = new DashStyle(new double[] { 5, 5 }, 5);

            if(_pen.CanFreeze)
            {
                _pen.Freeze();
            }
        }

        public override void Highlight(DrawingContext dc, GeometryStyleBase geometryStyle)
        {
            if (null == dc || !(geometryStyle is ImageStyle))
                return;

            ImageStyle style = geometryStyle as ImageStyle;

            if (!_moving)
            {
                _beforeMoveFirstPoint = geometryStyle.FirstPoint;
                _beforeMoveSecondPoint = geometryStyle.SecondPoint;
            }

            if (style.ImageUri == null)
            {
                dc.DrawRectangle(Brushes.Transparent, _pen, new Rect(geometryStyle.FirstPoint, geometryStyle.SecondPoint));
            }
            else
            {
                BitmapSource source = new System.Windows.Media.Imaging.BitmapImage(style.ImageUri);
                dc.DrawImage(source, new Rect(geometryStyle.FirstPoint, geometryStyle.SecondPoint));
            }
        }

        public override void Render(DrawingContext dc, GeometryStyleBase geometryStyle)
        {

            if (null == dc || !(geometryStyle is ImageStyle))
                return;

            ImageStyle style = geometryStyle as ImageStyle;

            if (!_moving)
            {
                _beforeMoveFirstPoint = geometryStyle.FirstPoint;
                _beforeMoveSecondPoint = geometryStyle.SecondPoint;
            }

            if (style.ImageUri == null)
            {
                dc.DrawRectangle(Brushes.Transparent, _pen, new Rect(geometryStyle.FirstPoint, geometryStyle.SecondPoint));
            }
            else
            {
                BitmapSource source = new System.Windows.Media.Imaging.BitmapImage(style.ImageUri);
                dc.DrawImage(source, new Rect(geometryStyle.FirstPoint, geometryStyle.SecondPoint));
            }
        }
    }
}
