
using XCode.Module.SimplePS.Geometry.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace XCode.Module.SimplePS.Geometry.Action
{
    /// <summary>
    /// Geometry行为接口
    /// </summary>
    internal interface GeometryBaseAction
    {
        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="style">Geometry样式</param>
        void Render(DrawingContext dc, GeometryStyleBase style);

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="style">Geometry样式</param>
        void Refresh(DrawingContext dc, GeometryStyleBase style);

        /// <summary>
        /// 平移
        /// </summary>
        /// <param name="visual"></param>
        /// <param name="style"></param>
        void Move(DrawingContext dc, GeometryStyleBase style, double offsetX, double offsetY);

        /// <summary>
        /// 高亮
        /// </summary>
        /// <param name="visual"></param>
        /// <param name="style"></param>
        void Highlight(DrawingContext dc, GeometryStyleBase style);

        /// <summary>
        /// 隐藏
        /// </summary>
        /// <param name="visual"></param>
        /// <param name="style"></param>
        void Hide(DrawingContext dc, GeometryStyleBase style);

        /// <summary>
        /// 重置状态
        /// </summary>
        void ResetState();
    }
}
