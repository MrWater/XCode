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
    /// 三角形Geometry
    /// </summary>
    internal class Triangle : VectorGeometryBase
    {
        public Triangle(GeometryStyleBase style, GeometryBaseAction action)
            : base()
        {
            Style = style;
            Action = action;
        }

        public override object Clone()
        {
            Triangle triangle = new Triangle(Style, Action);
            triangle.Render();
            return triangle;
        }
    }
}
