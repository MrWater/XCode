using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Module.SimplePS.Common.Style
{
    /// <summary>
    /// 样式Attribute
    /// </summary>
    internal class StyleAttribute : Attribute
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 后缀单位
        /// </summary>
        public string Measure { get; set; }

        /// <summary>
        /// 是否可编辑
        /// </summary>
        public bool Editable { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string ToolTip { get; set; }

        public StyleAttribute()
        {
            Editable = true;
            ToolTip = "";
            Measure = "";
            DisplayName = "";
        }
    }
}
