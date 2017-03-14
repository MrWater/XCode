using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Framework
{
    /// <summary>
    /// 句柄类
    /// 使用句柄而不直接使用对象，减少比较对象的时间开销
    /// </summary>
    public sealed class Handle
    {
        /// <summary>
        /// 句柄值
        /// </summary>
        public string Value { get; private set; }

        private Handle()
        {
        }

        /// <summary>
        /// 生成新句柄
        /// </summary>
        /// <returns></returns>
        public static Handle NewHandle()
        {
            return new Handle() { Value = Guid.NewGuid().ToString().ToUpper().Replace("-", "") };
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Handle))
                return false;

            return this.Value == ((Handle)obj).Value;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}
