using XCode.Module.SimplePS.Geometry.GeometryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace XCode.Module.SimplePS.Geometry.GeometryAction
{
    /// <summary>
    /// Geometry行为接口
    /// </summary>
    internal interface IGeometryAction
    {
        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="GeometryStyle">Geometry样式</param>
        void Render(DrawingContext dc, GeometryStyleBase GeometryStyle);

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="GeometryStyle">Geometry样式</param>
        void Refresh(DrawingContext dc, GeometryStyleBase GeometryStyle);

        /// <summary>
        /// 平移
        /// </summary>
        /// <param name="visual"></param>
        /// <param name="GeometryStyle"></param>
        void Move(DrawingContext dc, GeometryStyleBase GeometryStyle, double offsetX, double offsetY, bool stop = false);

        /// <summary>
        /// 高亮
        /// </summary>
        /// <param name="visual"></param>
        /// <param name="GeometryStyle"></param>
        void HighLight(DrawingContext dc, GeometryStyleBase GeometryStyle);

        /// <summary>
        /// 隐藏
        /// </summary>
        /// <param name="visual"></param>
        /// <param name="GeometryStyle"></param>
        void Hide(DrawingContext dc, GeometryStyleBase GeometryStyle);
    }
}
