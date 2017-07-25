using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using XCode.Module.SimplePS.Geometry.Style;

namespace XCode.Module.SimplePS.Geometry.Action
{
    /// <summary>
    /// Geometry行为抽象类
    /// </summary>
    internal abstract class GeometryActionBase : GeometryBaseAction
    {
        /// <summary>
        /// 是否正在移动
        /// </summary>
        protected bool _moving;
        /// <summary>
        /// 移动前控制点1
        /// </summary>
        protected Point _beforeMoveFirstPoint;
        /// <summary>
        /// 移动前控制点2
        /// </summary>
        protected Point _beforeMoveSecondPoint;

        protected GeometryActionBase()
        {
        }
        
        public void Refresh(DrawingContext dc, GeometryStyleBase geometryStyle)
        {
            Render(dc, geometryStyle);
        }

        public abstract void Highlight(DrawingContext dc, GeometryStyleBase geometryStyle);

        public virtual void Move(DrawingContext dc, GeometryStyleBase geometryStyle, double offsetX, double offsetY)
        {
            if (null == dc)
                return;
            
            geometryStyle.FirstPoint = new Point() { X = _beforeMoveFirstPoint.X + offsetX, Y = _beforeMoveFirstPoint.Y + offsetY };
            geometryStyle.SecondPoint = new Point() { X = _beforeMoveSecondPoint.X + offsetX, Y = _beforeMoveSecondPoint.Y + offsetY };

            if (geometryStyle.Highlight)
            {
                Highlight(dc, geometryStyle);
            }
            else
            {
                Render(dc, geometryStyle);
            }

            _moving = true;
        }

        public abstract void Render(DrawingContext dc, GeometryStyleBase geometryStyle);

        public void Hide(DrawingContext dc, GeometryStyleBase geometryStyle)
        {
            //什么也不干就是隐藏
        }

        public void ResetState()
        {
            _moving = false;
        }
    }
}
