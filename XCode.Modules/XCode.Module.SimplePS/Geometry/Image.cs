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
    /// 图片Geometry
    /// </summary>
    internal class Image : ImageGeometryBase
    {
        public Image(GeometryStyleBase style, GeometryBaseAction action)
            : base()
        {
            Style = style;
            Action = action;
        }

        public override object Clone()
        {
            Image image = new Image(Style, Action);
            image.Render();
            return image;
        }
    }
}
