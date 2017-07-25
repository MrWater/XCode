using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Module.SimplePS.Common
{
    /// <summary>
    /// 渲染行为
    /// </summary>
    internal interface IRenderAction
    {
        /// <summary>
        /// 渲染
        /// </summary>
        void Render();

        /// <summary>
        /// 刷新
        /// </summary>
        void Refresh();

        /// <summary>
        /// 隐藏
        /// </summary>
        void Hide();

        /// <summary>
        /// 高亮
        /// </summary>
        void Highlight();

        /// <summary>
        /// 平移
        /// </summary>
        /// <param name="offsetX"></param>
        /// <param name="offsetY"></param>
        void Move(double offsetX, double offsetY);

        /// <summary>
        /// 渲染完成调用，重置状态
        /// </summary>
        void ResetState();
    }
}
