using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Framework.Message_
{
    public class Messenger : IMessenger
    {
        public static Messenger Default { get; set; }

        private Messenger() { }

        static Messenger()
        {
            Default = new Messenger();
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
