using XCode.Module.SimplePS.Geometry.GeometryAction;
using XCode.Module.SimplePS.Geometry.GeometryProperty;
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
    internal class Line : VectorGeometry
    {
        public Line(GeometryStyleBase style, GeometryActionBase action)
            : base()
        {
            Style = style;
            Action = action;
        } 
    }
}
