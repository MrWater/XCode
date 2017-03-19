using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using XCode.Framework.Message_;

namespace XCode.Framework.Module
{
    /// <summary>
    /// 抽象模块类
    /// </summary>
    public abstract class ModuleBase : IModule
    {
        /// <summary>
        /// 模块的消息队列
        /// </summary>
        private MessageQueue _messageQueue;
        
        /// <summary>
        /// 保护构造函数
        /// </summary>
        protected ModuleBase()
        {
            Handle = Handle.NewHandle();
            _messageQueue = new MessageQueue();
        }

        #region IModule接口实现
        public abstract UserControl Entry { get; }

        public abstract Window Owner { get; set; }

        public abstract string Name { get; set; }

        public Handle Handle { get; private set; }

        public virtual MessageResult MessageFunc(IMessage message)
        {
            return default(MessageResult);
        }
        #endregion
    }
}
