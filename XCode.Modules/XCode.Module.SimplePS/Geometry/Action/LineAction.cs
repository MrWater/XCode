using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

using XCode.Module.SimplePS.Geometry.Style;
using System.Windows;

namespace XCode.Module.SimplePS.Geometry.Action
{
    /// <summary>
    /// 线条Action
    /// </summary>
    internal class LineAction : GeometryActionBase
    {
        public override void Highlight(DrawingContext dc, GeometryStyleBase geometryStyle)
        {
            if (null == dc || !(geometryStyle is LineStyle))
                return;

            LineStyle style = geometryStyle as LineStyle;
            Pen pen = new Pen(style.LineBrush, 6);
            pen.DashStyle = style.DashStyle;

            if (pen.CanFreeze)
                pen.Freeze();

            if(!_moving)
            {
                _beforeMoveFirstPoint = geometryStyle.FirstPoint;
                _beforeMoveSecondPoint = geometryStyle.SecondPoint;
            }

            dc.DrawLine(pen, geometryStyle.FirstPoint, geometryStyle.SecondPoint);
        }

        public override void Render(DrawingContext dc, GeometryStyleBase geometryStyle)
        {
            if (null == dc || !(geometryStyle is LineStyle))
                return;

            LineStyle style = geometryStyle as LineStyle;
            Pen pen = new Pen(style.LineBrush, style.LineWidth);
            pen.DashStyle = style.DashStyle;

            if (pen.CanFreeze)
                pen.Freeze();

            if (!_moving)
            {
                _beforeMoveFirstPoint = geometryStyle.FirstPoint;
                _beforeMoveSecondPoint = geometryStyle.SecondPoint;
            }

            dc.DrawLine(pen, geometryStyle.FirstPoint, geometryStyle.SecondPoint);
        }
    }
}
