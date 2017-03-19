using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Framework.Message_
{
    /// <summary>
    /// 消息响应结果
    /// </summary>
    public struct MessageResult
    {
        /// <summary>
        /// 是否正常执行
        /// </summary>
        public bool Ok { get; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ok"></param>
        /// <param name="error"></param>
        public MessageResult(bool ok, string error)
        {
            this.Ok = ok;
            this.Error = error;
        }
    }
}
