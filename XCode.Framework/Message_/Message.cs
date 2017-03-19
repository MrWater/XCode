using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Framework.Message_
{
    /// <summary>
    /// 消息接口
    /// </summary>
    public class Message<TParameter> : IMessage
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public MessageTypes MessageType { get; }

        /// <summary>
        /// 消息参数
        /// </summary>
        public TParameter Parameter { get; }

        /// <summary>
        /// 消息状态
        /// TODO:Set方法如何禁止随意修改
        /// </summary>
        public MessageState MessageState { get; set; }

        /// <summary>
        /// 消息响应完成事件
        /// </summary>
        public EventHandler Completed;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="parameter"></param>
        public Message(MessageTypes messageType, TParameter parameter)
        {
            this.MessageType = messageType;
            this.Parameter = parameter;
            this.MessageState = MessageState.Initialized;
        }
    }
}
