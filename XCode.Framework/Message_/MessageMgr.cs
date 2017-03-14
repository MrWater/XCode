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

        /// <summary>
        /// 句柄和消息处理过程的映射
        /// </summary>
        private Dictionary<Handle, MessageFunc> _msgHookDic;

        static MessageMgr()
        {
            Default = new MessageMgr();
        }

        /// <summary>
        /// 添加挂接，如果已存在则覆盖
        /// </summary>
        /// <param name="handle"></param>
        /// <param name=""></param>
        public void AddHook(Handle handle, MessageFunc messageFunc)
        {
            _msgHookDic[handle] = messageFunc;
        }

        /// <summary>
        /// 移除挂接
        /// </summary>
        /// <param name="handle"></param>
        public void RemoveHook(Handle handle)
        {
            _msgHookDic.Remove(handle);
        }

        /// <summary>
        /// 得到相应的消息处理过程
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public MessageFunc GetMessageFunc(Handle handle)
        {
            if (_msgHookDic.ContainsKey(handle))
                return _msgHookDic[handle];

            return null;
        }
    }
}
