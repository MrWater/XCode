using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using XCode.Framework.Message_;

namespace XCode.Framework.Module
{
    /// <summary>
    /// 模块接口
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// 获取入口视图
        /// </summary>
        UserControl Entry { get; }

        /// <summary>
        /// 
        /// </summary>
        Window Owner { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 模块句柄
        /// </summary>
        Handle Handle { get; }

        /// <summary>
        /// 消息处理过程
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        MessageResult MessageFunc(IMessage message);
    }
}
