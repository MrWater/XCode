using XCode.Module.SimplePS.Common;
using XCode.Module.SimplePS.Geometry.Action;
using XCode.Module.SimplePS.Geometry.GeometrySpecialAction;
using XCode.Module.SimplePS.Geometry.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace XCode.Module.SimplePS.Geometry
{
    internal abstract class GeometryBase : DrawingVisual, IGeometry, ICloneable
    {
        public GeometryStyleBase Style { get; set; }
        public GeometryBaseAction Action { get; set; }
        public Handle Handle { get; private set; }
        public SpecialActionGroup SpecialActionGroup { get; set; }

        protected GeometryBase()
        {
            Handle = Handle.NewHandle();
            SpecialActionGroup = new SpecialActionGroup();
        }

        #region 行为
        public virtual void Refresh()
        {
            if(Style.Highlight)
            {
                Highlight();
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
            if (SpecialActionGroup != null)
            {
                SpecialActionGroup.Excute(Style);
            }

            using (DrawingContext dc = this.RenderOpen())
            {
                Action.Render(dc, Style);
            }
        }

        public virtual void Move(double offsetX, double offsetY)
        {
            using (DrawingContext dc = this.RenderOpen())
            {
                Action.Move(dc, Style, offsetX, offsetY);
            }
        }

        public virtual void Highlight()
        {
            Style.Highlight = true;

            if (SpecialActionGroup != null)
            {
                SpecialActionGroup.Excute(Style);
            }

            using (DrawingContext dc = this.RenderOpen())
            {
                Action.Highlight(dc, Style);
            }
        }

        public virtual void ResetState()
        {
            Action.ResetState();
        }
        #endregion

        public abstract object Clone();
    }
}
