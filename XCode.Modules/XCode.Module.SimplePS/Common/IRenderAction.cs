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
        void HighLight();

        /// <summary>
        /// 平移
        /// </summary>
        /// <param name="offsetX"></param>
        /// <param name="offsetY"></param>
        /// <param name="stop">True:表示移动后改变属性 False:仅仅是移动，不改变实际属性</param>
        void Move(double offsetX, double offsetY, bool stop = false);
    }
}
