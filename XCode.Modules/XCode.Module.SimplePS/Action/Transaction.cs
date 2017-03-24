using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Module.SimplePS.Action
{
    /// <summary>
    /// 事务，用于提交Action
    /// </summary>
    internal class Transaction
    {
        /// <summary>
        /// 撤销
        /// </summary>
        public void Undo()
        {

        }

        /// <summary>
        /// 重做
        /// </summary>
        public void Redo()
        {

        }

        /// <summary>
        /// 提交所有修改，执行刷新
        /// </summary>
        public void Submit()
        {
        }

        /// <summary>
        /// 对于有异常的执行回滚
        /// </summary>
        public void Rollback()
        {

        }
    }
}
