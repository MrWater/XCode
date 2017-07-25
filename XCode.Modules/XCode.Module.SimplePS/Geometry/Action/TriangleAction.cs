
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
    /// 三角形Action
    /// </summary>
    internal class TriangleAction : GeometryActionBase
    {
        public override void Highlight(DrawingContext dc, GeometryStyleBase geometryStyle)
        {
            if (null == dc || !(geometryStyle is TriangleStyle))
                return;

            TriangleStyle style = geometryStyle as TriangleStyle;
            Pen pen = new Pen(style.LineBrush, 6);
            pen.DashStyle = style.DashStyle;

            if (pen.CanFreeze)
                pen.Freeze();

            if (!_moving)
            {
                _beforeMoveFirstPoint = geometryStyle.FirstPoint;
                _beforeMoveSecondPoint = geometryStyle.SecondPoint;
            }

            PathGeometry triangle = new PathGeometry();
            PathFigure figure = new PathFigure();
            figure.IsClosed = true;
            figure.StartPoint = new Point((geometryStyle.FirstPoint.X + geometryStyle.SecondPoint.X) / 2, geometryStyle.FirstPoint.Y);
            figure.Segments = new PathSegmentCollection()
            {
                new LineSegment() { Point = geometryStyle.SecondPoint },
                new LineSegment() { Point = new Point(geometryStyle.FirstPoint.X, geometryStyle.SecondPoint.Y) }
            };

            triangle.Figures = new PathFigureCollection() { figure };

            dc.DrawGeometry(style.FillBrush, pen, triangle);
        }

        public override void Render(DrawingContext dc, GeometryStyleBase geometryStyle)
        {

            if (null == dc || !(geometryStyle is TriangleStyle))
                return;

            TriangleStyle style = geometryStyle as TriangleStyle;
            Pen pen = new Pen(style.LineBrush, 6);
            pen.DashStyle = style.DashStyle;

            if (pen.CanFreeze)
                pen.Freeze();

            if (!_moving)
            {
                _beforeMoveFirstPoint = geometryStyle.FirstPoint;
                _beforeMoveSecondPoint = geometryStyle.SecondPoint;
            }

            PathGeometry triangle = new PathGeometry();
            PathFigure figure = new PathFigure();
            figure.IsClosed = true;
            figure.StartPoint = new Point((geometryStyle.FirstPoint.X + geometryStyle.SecondPoint.X) / 2, geometryStyle.FirstPoint.Y);
            figure.Segments = new PathSegmentCollection()
            {
                new LineSegment() { Point = geometryStyle.SecondPoint },
                new LineSegment() { Point = new Point(geometryStyle.FirstPoint.X, geometryStyle.SecondPoint.Y) }
            };

            triangle.Figures = new PathFigureCollection() { figure };

            dc.DrawGeometry(style.FillBrush, pen, triangle);
        }
    }
}
