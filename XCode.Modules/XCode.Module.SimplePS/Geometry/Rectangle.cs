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
    /// 矩形Geometry
    /// </summary>
    internal class Rectangle : VectorGeometryBase
    {
        public Rectangle(GeometryStyleBase style, GeometryBaseAction action)
            : base()
        {
            Style = style;
            Action = action;
        }

        public override object Clone()
        {
            Rectangle rectangle = new Rectangle(Style, Action);
            rectangle.Render();
            return rectangle;
        }
    }
}
