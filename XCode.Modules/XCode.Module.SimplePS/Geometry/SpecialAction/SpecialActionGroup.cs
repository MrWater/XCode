
using XCode.Module.SimplePS.Geometry.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Module.SimplePS.Geometry.GeometrySpecialAction
{
    internal class SpecialActionGroup : List<SpecialActionBase>, ISpecialAction
    {
        public void Excute(GeometryStyleBase style)
        {
            if (style == null)
                return;

            foreach (var strategy in this)
            {
                strategy.Excute(style);
            }
        }
    }
}
