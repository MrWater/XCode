using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Framework.Message_
{
    /// <summary>
    /// 消息处理过程
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public delegate MessageResult MessageFunc(IMessage message);
}
