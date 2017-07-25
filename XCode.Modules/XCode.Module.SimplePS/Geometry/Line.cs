using XCode.Module.SimplePS.Geometry.Action;
using XCode.Module.SimplePS.Geometry.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace XCode.Module.SimplePS.Geometry
{
    /// <summary>
    /// 线条Geometry
    /// </summary>
    internal class Line : VectorGeometryBase
    {
        public Line(GeometryStyleBase style, GeometryBaseAction action)
            : base()
        {
            Style = style;
            Action = action;
        }

        public override object Clone()
        {
            Line line = new Line(Style, Action);
            line.Render();
            return line;
        }
    }
}
