using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Framework.Message_
{
    /// <summary>
    /// 消息控制中心
    /// </summary>
    internal sealed class MessageMgr
    {
        public static MessageMgr Default { get; }

        private MessageMgr() { }

        static MessageMgr()
        {
            Default = new MessageMgr();
        }
    }
}
