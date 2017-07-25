using XCode.Module.SimplePS.Common;
using XCode.Module.SimplePS.Common.Paint;
using XCode.Module.SimplePS.Common.Style;
using XCode.Module.SimplePS.Geometry;
using XCode.Module.SimplePS.Layer;
using XCode.Module.SimplePS.Paint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XCode.Module.SimplePS.Paint.Tool
{
    /// <summary>
    /// 绘制工具抽象类
    /// </summary>
    internal abstract class PaintToolBase : ObservableObject, IStyle, IPaintBehavior
    {
        protected GeometryBase _geometry;
        protected List<LayerBase> _layers;
        protected PaintContext _paintContext;

        /// <summary>
        /// 开始执行绘制
        /// 初始化
        /// </summary>
        /// <param name="context"></param>
        /// <param name="beginPoint"></param>
        /// <returns></returns>
        public abstract PaintResult BeginPaint(PaintContext context, Point beginPoint);

        /// <summary>
        /// 执行绘制
        /// 不会刷新
        /// </summary>
        /// <param name="currentPoint"></param>
        public abstract void Paint(Point currentPoint);

        /// <summary>
        /// 结束绘制
        /// 事后处理状态，准备下次绘制
        /// </summary>
        public abstract void EndPaint();
    }
}
