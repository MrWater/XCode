using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Module.SimplePS.Geometry.Shell
{
    /// <summary>
    /// 图元壳接口类
    /// 壳：拖动壳进行图元的联动，例如位移
    /// 该部分使用具有鼠标键盘事件的控件实现，交互较多
    /// </summary>
    internal interface IGeometryShell
    {
        /// <summary>
        /// 绑定
        /// 应实现壳和图元各渲染事件的联动
        /// </summary>
        /// <param name="geometry"></param>
        void Bind(GeometryBase geometry);
    }
}
