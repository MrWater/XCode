using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Module.SimplePS.Action
{
    /// <summary>
    /// 所有操作的接口
    /// </summary>
    internal interface IAction
    {
        /// <summary>
        /// 具体执行方法
        /// 不执行刷新界面
        /// </summary>
        void Do();
    }
}
