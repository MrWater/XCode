using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Module.SimplePS.Common
{
    /// <summary>
    /// 句柄 
    /// 唯一识别码
    /// </summary>
    internal class Handle
    {
        private string _guid;

        private Handle()
        {
            _guid = Guid.NewGuid().ToString().Replace("-", "");
        }

        public static Handle NewHandle()
        {
            return new Handle();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Handle))
                return false;

            return _guid == (obj as Handle)._guid;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
