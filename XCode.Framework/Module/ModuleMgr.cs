using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Framework.Module
{
    /// <summary>
    /// 模块管理
    /// </summary>
    internal class ModuleMgr
    {
        /// <summary>
        /// 单例
        /// </summary>
        public static readonly ModuleMgr Instance = new ModuleMgr();

        private ModuleMgr() { }
    }
}
