
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
    /// 圆形Action
    /// </summary>
    internal class CircleAction : GeometryActionBase
    {
        public override void Highlight(DrawingContext dc, GeometryStyleBase geometryStyle)
        {
            if (null == dc || !(geometryStyle is CircleStyle))
                return;

            CircleStyle style = geometryStyle as CircleStyle;
            Pen pen = new Pen(style.LineBrush, 6);
            pen.DashStyle = style.DashStyle;

            if (pen.CanFreeze)
                pen.Freeze();

            if (!_moving)
            {
                _beforeMoveFirstPoint = geometryStyle.FirstPoint;
                _beforeMoveSecondPoint = geometryStyle.SecondPoint;
            }

            dc.DrawEllipse(style.FillBrush, pen, new Point(
                (geometryStyle.FirstPoint.X + geometryStyle.SecondPoint.X) / 2, (geometryStyle.FirstPoint.Y + geometryStyle.SecondPoint.Y) / 2),
                Math.Abs(geometryStyle.FirstPoint.X - geometryStyle.SecondPoint.X) / 2, Math.Abs(geometryStyle.FirstPoint.Y - geometryStyle.SecondPoint.Y) / 2);
        }

        public override void Render(DrawingContext dc, GeometryStyleBase geometryStyle)
        {

            if (null == dc || !(geometryStyle is CircleStyle))
                return;

            CircleStyle style = geometryStyle as CircleStyle;
            Pen pen = new Pen(style.LineBrush, 6);
            pen.DashStyle = style.DashStyle;

            if (pen.CanFreeze)
                pen.Freeze();

            if (!_moving)
            {
                _beforeMoveFirstPoint = geometryStyle.FirstPoint;
                _beforeMoveSecondPoint = geometryStyle.SecondPoint;
            }

            dc.DrawEllipse(style.FillBrush, pen, new Point(
                (geometryStyle.FirstPoint.X + geometryStyle.SecondPoint.X) / 2, (geometryStyle.FirstPoint.Y + geometryStyle.SecondPoint.Y) / 2),
                Math.Abs(geometryStyle.FirstPoint.X - geometryStyle.SecondPoint.X) / 2, Math.Abs(geometryStyle.FirstPoint.Y - geometryStyle.SecondPoint.Y) / 2);
        }
    }
}
