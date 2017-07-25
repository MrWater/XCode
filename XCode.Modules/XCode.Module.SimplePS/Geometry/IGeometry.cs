using XCode.Module.SimplePS.Common;
using XCode.Module.SimplePS.Geometry.Action;
using XCode.Module.SimplePS.Geometry.GeometrySpecialAction;
using XCode.Module.SimplePS.Geometry.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Module.SimplePS.Geometry
{
    /// <summary>
    /// Geometry接口
    /// </summary>
    internal interface IGeometry : IRenderAction
    {
        GeometryStyleBase Style { get; set; }
        GeometryBaseAction Action { get; set; }
        Handle Handle { get; }
        SpecialActionGroup SpecialActionGroup { get; set; }
    }
}
