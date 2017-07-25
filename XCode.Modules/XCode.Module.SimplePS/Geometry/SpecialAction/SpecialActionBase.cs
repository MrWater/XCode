using XCode.Module.SimplePS.Geometry.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace XCode.Module.SimplePS.Geometry.GeometrySpecialAction
{
    /// <summary>
    /// 特殊策略基类
    /// </summary>
    internal abstract class SpecialActionBase : ISpecialAction
    {
        public abstract void Excute(GeometryStyleBase style);
    }
}
