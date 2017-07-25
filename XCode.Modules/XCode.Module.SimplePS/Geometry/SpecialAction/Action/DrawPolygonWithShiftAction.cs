using XCode.Module.SimplePS.Geometry.GeometrySpecialAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCode.Module.SimplePS.Geometry.Style;
using System.Windows;

namespace XCode.Module.SimplePS.Geometry.SpecialAction.Action
{
    /// <summary>
    /// 按住shift绘制多边形
    /// </summary>
    internal class DrawPolygonWithShiftAction : SpecialActionBase
    {
        public static readonly DrawPolygonWithShiftAction Instance;

        private DrawPolygonWithShiftAction()
            : base()
        {

        }

        static DrawPolygonWithShiftAction()
        {
            Instance = new DrawPolygonWithShiftAction();
        }

        public override void Excute(GeometryStyleBase style)
        {
            if (style == null || style is LineStyle)
                return;

            double dx = style.SecondPoint.X - style.FirstPoint.X;
            double dy = style.SecondPoint.Y - style.FirstPoint.Y;
            double atan = Math.Atan(dy / dx);

            if(dx > 0)
            {
                if(dy > 0)
                {
                    style.SecondPoint = new Point(style.SecondPoint.X, style.FirstPoint.Y + dx);
                }
                else
                {
                    style.SecondPoint = new Point(style.SecondPoint.X, style.FirstPoint.Y - dx);
                }
            }
            else
            {
                if (dy > 0)
                {
                    style.SecondPoint = new Point(style.SecondPoint.X, style.FirstPoint.Y - dx);
                }
                else
                {
                    style.SecondPoint = new Point(style.SecondPoint.X, style.FirstPoint.Y + dx);
                }
            }
        }
    }
}
