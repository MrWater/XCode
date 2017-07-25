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
    /// 文本Geometry
    /// </summary>
    internal class Text : VectorGeometryBase
    {
        public Text(GeometryStyleBase style, GeometryBaseAction action)
            : base()
        {
            Style = style;
            Action = action;
        }

        public override object Clone()
        {
            Text text = new Text(Style, Action);
            text.Render();
            return text;
        }
    }
}
