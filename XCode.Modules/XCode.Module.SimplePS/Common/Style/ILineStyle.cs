using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace XCode.Module.SimplePS.Common.Style
{
    /// <summary>
    /// 具有线的样式
    /// </summary>
    internal interface ILineStyle 
    {
        /// <summary>
        /// 线条宽度
        /// </summary>
        double LineWidth { get; set; }
        
        /// <summary>
        /// 线条颜色
        /// </summary>
        Brush LineBrush { get; set; }

        /// <summary>
        /// 线条样式
        /// </summary>
        DashStyle DashStyle { get; set; }
    }
}
