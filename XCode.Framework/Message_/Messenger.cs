using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Framework.Message_
{
    public class Messenger : IMessenger
    {
        public void AddHook(Handle recipient, MessageFunc messageFunc)
        {
            MessageMgr.Default.AddHook(recipient, messageFunc);
        }

        public void RemoveHook(Handle recipient)
        {
            MessageMgr.Default.RemoveHook(recipient);
        }

        public MessageResult SendMessage(Handle recipient, IMessage message)
        {
            throw new NotImplementedException();
        }

        public void PostMessage(Handle recipient, IMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
