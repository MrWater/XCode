using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using XCode.Module.SimplePS.Geometry.GeometryProperty;
using XCode.Module.SimplePS.Geometry.GeometryStyle.Style;
using System.Windows;

namespace XCode.Module.SimplePS.Geometry.GeometryAction.Action
{
    /// <summary>
    /// 线条Action
    /// </summary>
    internal class LineAction : GeometryActionBase
    {
        public override void HighLight(DrawingContext dc, GeometryStyleBase GeometryStyle)
        {
            HighLight(dc, GeometryStyle, GeometryStyle.FirstPoint, GeometryStyle.SecondPoint);
        }

        private void HighLight(DrawingContext dc, GeometryStyleBase GeometryStyle, Point firstPoint, Point secondPoint)
        {
            if (null == dc || !(GeometryStyle is LineStyle))
                return;

            LineStyle style = GeometryStyle as LineStyle;
            Pen pen = new Pen(style.LineBrush, 6);
            pen.DashStyle = style.DashStyle;

            if (pen.CanFreeze)
                pen.Freeze();

            dc.DrawLine(pen, firstPoint, secondPoint);
        }

        public override void Move(DrawingContext dc, GeometryStyleBase GeometryStyle, double offsetX, double offsetY, bool stop = false)
        {
            if (null == dc || !(GeometryStyle is LineStyle))
                return;

            LineStyle style = GeometryStyle as LineStyle;
            Pen pen = new Pen(style.LineBrush, style.LineWidth);
            pen.DashStyle = style.DashStyle;

            if (pen.CanFreeze)
                pen.Freeze();

            Point firstPt = new Point() { X = GeometryStyle.FirstPoint.X + offsetX, Y = GeometryStyle.FirstPoint.Y + offsetY };
            Point secondPt = new Point() { X = GeometryStyle.SecondPoint.X + offsetX, Y = GeometryStyle.SecondPoint.Y + offsetY };

            if(GeometryStyle.HighLight)
            {
                HighLight(dc, GeometryStyle, firstPt, secondPt);
            }
            else
            {
                Render(dc, GeometryStyle, firstPt, secondPt);
            }

            if (stop)
            {
                GeometryStyle.FirstPoint = firstPt;
                GeometryStyle.SecondPoint = secondPt;
            }
        }

        public override void Render(DrawingContext dc, GeometryStyleBase GeometryStyle)
        {
            Render(dc, GeometryStyle, GeometryStyle.FirstPoint, GeometryStyle.SecondPoint);
        }

        private void Render(DrawingContext dc, GeometryStyleBase GeometryStyle, Point firstPoint, Point secondPoint)
        {
            if (null == dc || !(GeometryStyle is LineStyle))
                return;

            LineStyle style = GeometryStyle as LineStyle;
            Pen pen = new Pen(style.LineBrush, style.LineWidth);
            pen.DashStyle = style.DashStyle;

            if (pen.CanFreeze)
                pen.Freeze();

            dc.DrawLine(pen, firstPoint, secondPoint);
        }
    }
}
