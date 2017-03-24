using XCode.Module.SimplePS.Common;
using XCode.Module.SimplePS.Geometry.GeometryAction;
using XCode.Module.SimplePS.Geometry.GeometryProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace XCode.Module.SimplePS.Geometry
{
    internal abstract class GeometryBase : DrawingVisual, IGeometry
    {
        public GeometryStyleBase Style { get; set; }
        public GeometryActionBase Action { get; set; }
        public Handle Handle { get; private set; }
        public bool Visible { get; set; }

        protected GeometryBase()
        {
            Handle = Handle.NewHandle();
            Visible = true;
        }

        #region 行为
        public virtual void Refresh()
        {
            if(Style.HighLight)
            {
                HighLight();
            }
            else
            {
                Render();
            }
        }

        public virtual void Hide()
        {
            using (DrawingContext dc = this.RenderOpen())
            {
                Action.Hide(dc, Style);
            }
        }

        public virtual void Render()
        {
            using (DrawingContext dc = this.RenderOpen())
            {
                Action.Render(dc, Style);
            }
        }

        public virtual void Move(double offsetX, double offsetY, bool stop = false)
        {
            using (DrawingContext dc = this.RenderOpen())
            {
                Action.Move(dc, Style, offsetX, offsetY, stop);
            }
        }

        public virtual void HighLight()
        {
            Style.HighLight = true;

            using (DrawingContext dc = this.RenderOpen())
            {
                Action.HighLight(dc, Style);
            }
        } 
        #endregion
    }
}
