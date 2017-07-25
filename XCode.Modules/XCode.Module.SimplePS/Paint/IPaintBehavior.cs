using XCode.Module.SimplePS.Common.Paint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XCode.Module.SimplePS.Paint
{
    internal interface IPaintBehavior
    {
        /// <summary>
        /// 开始执行绘制
        /// 初始化
        /// </summary>
        /// <param name="context"></param>
        /// <param name="beginPoint"></param>
        /// <returns></returns>
        PaintResult BeginPaint(PaintContext context, Point beginPoint);

        /// <summary>
        /// 执行绘制
        /// 不会刷新
        /// </summary>
        /// <param name="currentPoint"></param>
        void Paint(Point currentPoint);

        /// <summary>
        /// 结束绘制
        /// 事后处理状态，准备下次绘制
        /// </summary>
        void EndPaint();
    }
}
