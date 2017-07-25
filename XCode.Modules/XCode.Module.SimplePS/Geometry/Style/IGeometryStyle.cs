using XCode.Module.SimplePS.Common.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XCode.Module.SimplePS.Geometry.Style
{
    internal interface IGeometryStyle : IStyle
    {
        Point FirstPoint { get; set; }
        Point SecondPoint { get; set; }
        double Height { get; set; }
        double Width { get; set; }
        bool Highlight { get; set; }
    }
}
