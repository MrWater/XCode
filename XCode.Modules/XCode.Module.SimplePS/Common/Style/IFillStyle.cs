using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace XCode.Module.SimplePS.Common.Style
{
    /// <summary>
    /// 具有填充样式
    /// </summary>
    internal interface IFillStyle
    {
        /// <summary>
        /// 填充颜色
        /// </summary>
        Brush FillBrush { get; set; }
    }
}
