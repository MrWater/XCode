
using XCode.Module.SimplePS.Geometry.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Module.SimplePS.Geometry.GeometrySpecialAction
{
    /// <summary>
    /// 特殊的渲染策略接口
    /// </summary>
    internal interface ISpecialAction
    {
        /// <summary>
        /// 执行逻辑
        /// </summary>
        void Excute(GeometryStyleBase style);
    }
}
