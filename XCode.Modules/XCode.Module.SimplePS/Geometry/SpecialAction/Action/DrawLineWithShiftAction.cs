using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using XCode.Module.SimplePS.Geometry.Style;

namespace XCode.Module.SimplePS.Geometry.GeometrySpecialAction.Action
{
    /// <summary>
    /// 按住shift时的逻辑
    /// </summary>
    internal sealed class DrawLineWithShiftAction : SpecialActionBase
    {
        public static readonly DrawLineWithShiftAction Instance;

        private DrawLineWithShiftAction()
            : base()
        {

        }

        static DrawLineWithShiftAction()
        {
            Instance = new DrawLineWithShiftAction();
        }

        public override void Excute(GeometryStyleBase style)
        {
            if (style == null || !(style is LineStyle))
                return;

            double dx = style.SecondPoint.X - style.FirstPoint.X;
            double dy = style.SecondPoint.Y - style.FirstPoint.Y;
            double atan = Math.Atan(dy / dx);

            if (atan <= Math.PI / 2 - 0.57)
            {
                style.SecondPoint = new Point(style.SecondPoint.X, style.FirstPoint.Y);
            }
            else if (atan >= Math.PI / 2 + 0.57)
            {
                style.SecondPoint = new Point(style.FirstPoint.X, style.SecondPoint.Y);
            }
            else
            {
                style.SecondPoint = new Point(style.SecondPoint.X, style.FirstPoint.Y
                        + Math.Abs((style.SecondPoint.X - style.FirstPoint.X)));
            }
        }
    }
}
