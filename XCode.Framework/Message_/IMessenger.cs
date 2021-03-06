﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Framework.Message_
{
    /// <summary>
    /// 消息信使
    /// </summary>
    public interface IMessenger
    {
        /// <summary>
        /// 发送消息，并等待消息执行完才返回
        /// </summary>
        /// <param name="recipient"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        MessageResult SendMessage(Handle recipient, IMessage message);

        /// <summary>
        /// 发送消息，立即返回
        /// </summary>
        /// <param name="recipient"></param>
        /// <param name="message"></param>
        void PostMessage(Handle recipient, IMessage message);
    }
}
