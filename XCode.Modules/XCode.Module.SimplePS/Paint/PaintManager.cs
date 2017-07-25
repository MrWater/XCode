using Microsoft.Win32;
using XCode.Module.SimplePS.Geometry;
using XCode.Module.SimplePS.Geometry.Action;
using XCode.Module.SimplePS.Geometry.Style;
using XCode.Module.SimplePS.Layer;
using XCode.Module.SimplePS.Paint;
using XCode.Module.SimplePS.Paint.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace XCode.Module.SimplePS.Common.Paint
{
    /// <summary>
    /// 绘制工具
    /// </summary>
    internal class PaintManager : IPaintBehavior
    {
        public static readonly PaintManager Default = new PaintManager();

        private PaintToolBase _paintTool;

        private PaintManager()
        {
        }

        #region 通过绘制上下文控制所有渲染
        #region IPaintBehavior接口实现
        /// <summary>
        /// 开始执行绘制初始化
        /// </summary>
        /// <param name="GeometryType"></param>
        /// <param name="beginPoint"></param>
        /// <returns></returns>
        public PaintResult BeginPaint(PaintContext context, Point beginPoint)
        {
            if (context == null || context.PaintTool == null)
                return new PaintResult() { PaintLayerType = PaintLayerType.None };

            _paintTool = context.PaintTool;

            return context.PaintTool.BeginPaint(context, beginPoint);
        }

        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="currentPoint"></param>
        public void Paint(Point currentPoint)
        {
            if (_paintTool != null)
                _paintTool.Paint(currentPoint);
        }

        /// <summary>
        /// 结束绘制
        /// </summary>
        public void EndPaint()
        {
            if (_paintTool != null)
                _paintTool.EndPaint();
        }
        #endregion

        #region 控制当前图层移动
        /// <summary>
        /// 当前操作图层向左移动
        /// </summary>
        public void MoveLeft(PaintContext context, double offset)
        {
            if (context != null && context.OperationLayers != null)
            {
                foreach (var item in context.OperationLayers)
                {
                    item.Move(-offset, 0);
                    item.ResetState();
                    item.Refresh();
                }
            }
        }

        /// <summary>
        /// 当前操作图层向上移动
        /// </summary>
        public void MoveUp(PaintContext context, double offset)
        {
            if (context != null && context.OperationLayers != null)
            {
                foreach (var item in context.OperationLayers)
                {
                    item.Move(0, -offset);
                    item.ResetState();
                    item.Refresh();
                }
            }
        }

        /// <summary>
        /// 当前操作图层向右移动
        /// </summary>
        public void MoveRight(PaintContext context, double offset)
        {
            if (context != null && context.OperationLayers != null)
            {
                foreach (var item in context.OperationLayers)
                {
                    item.Move(offset, 0);
                    item.ResetState();
                    item.Refresh();
                }
            }
        }

        /// <summary>
        /// 当前操作图层向下移动
        /// </summary>
        public void MoveDown(PaintContext context, double offset)
        {
            if (context != null && context.OperationLayers != null)
            {
                foreach (var item in context.OperationLayers)
                {
                    item.Move(0, offset);
                    item.ResetState();
                    item.Refresh();
                }
            }
        }
        #endregion
        #endregion
    }
}
