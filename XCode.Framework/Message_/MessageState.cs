using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Framework.Message_
{
    /// <summary>
    /// 消息的各种状态
    /// </summary>
    public enum MessageState
    {
        /// <summary>
        /// 初始化完成
        /// </summary>
        Initialized,
        /// <summary>
        /// 进入消息队列，等待响应
        /// </summary>
        Waiting,
        /// <summary>
        /// 正在响应
        /// </summary>
        Responding,
        /// <summary>
        /// 响应完成
        /// </summary>
        Finished
    }
}
