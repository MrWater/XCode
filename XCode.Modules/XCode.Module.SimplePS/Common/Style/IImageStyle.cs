using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Module.SimplePS.Common.Style
{
    /// <summary>
    /// 具有图片url样式
    /// </summary>
    internal interface IImageStyle
    {
        Uri ImageUri { get; set; }
    }
}
