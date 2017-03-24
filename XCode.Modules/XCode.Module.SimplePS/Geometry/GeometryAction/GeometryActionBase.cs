using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using XCode.Module.SimplePS.Geometry.GeometryProperty;

namespace XCode.Module.SimplePS.Geometry.GeometryAction
{
    /// <summary>
    /// Geometry行为抽象类
    /// </summary>
    internal abstract class GeometryActionBase : IGeometryAction
    {
        protected GeometryActionBase()
        {
        }
        
        public void Refresh(DrawingContext dc, GeometryStyleBase GeometryStyle)
        {
            Render(dc, GeometryStyle);
        }

        public abstract void HighLight(DrawingContext dc, GeometryStyleBase GeometryStyle);

        public abstract void Move(DrawingContext dc, GeometryStyleBase GeometryStyle, double offsetX, double offsetY, bool stop = false);

        public abstract void Render(DrawingContext dc, GeometryStyleBase GeometryStyle);

        public void Hide(DrawingContext dc, GeometryStyleBase GeometryStyle)
        {
            //什么也不干就是隐藏
        }
    }
}
