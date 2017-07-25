using XCode.Module.SimplePS.Geometry.Action;
using XCode.Module.SimplePS.Geometry.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Module.SimplePS.Geometry
{
    /// <summary>
    /// 圆形Geometry
    /// </summary>
    internal class Circle : VectorGeometryBase
    {
        public Circle(GeometryStyleBase style, GeometryBaseAction action)
            : base()
        {
            Style = style;
            Action = action;
        }

        public override object Clone()
        {
            Circle circle = new Circle(Style, Action);
            circle.Render();
            return circle;
        }
    }
}
