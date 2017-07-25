
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
    /// 矩形Action
    /// </summary>
    internal class RectangleAction : GeometryActionBase
    {
        public override void Highlight(DrawingContext dc, GeometryStyleBase geometryStyle)
        {
            if (null == dc || !(geometryStyle is RectangleStyle))
                return;

            RectangleStyle style = geometryStyle as RectangleStyle;
            Pen pen = new Pen(style.LineBrush, 6);
            pen.DashStyle = style.DashStyle;

            if (pen.CanFreeze)
                pen.Freeze();

            if (!_moving)
            {
                _beforeMoveFirstPoint = geometryStyle.FirstPoint;
                _beforeMoveSecondPoint = geometryStyle.SecondPoint;
            }

            dc.DrawRectangle(style.FillBrush, pen, new Rect(geometryStyle.FirstPoint, geometryStyle.SecondPoint));
        }

        public override void Render(DrawingContext dc, GeometryStyleBase geometryStyle)
        {
            if (null == dc || !(geometryStyle is RectangleStyle))
                return;

            RectangleStyle style = geometryStyle as RectangleStyle;
            Pen pen = new Pen(style.LineBrush, 6);
            pen.DashStyle = style.DashStyle;

            if (pen.CanFreeze)
                pen.Freeze();

            if (!_moving)
            {
                _beforeMoveFirstPoint = geometryStyle.FirstPoint;
                _beforeMoveSecondPoint = geometryStyle.SecondPoint;
            }

            dc.DrawRectangle(style.FillBrush, pen, new Rect(geometryStyle.FirstPoint, geometryStyle.SecondPoint));
        }
    }
}
