using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace XCode.Module.SimplePS.Common
{
    public class DrawingCanvas : Canvas
    {
        /// <summary>
        /// 所有可视化对象
        /// </summary>
        protected List<Visual> _eles = new List<Visual>();
        private List<Visual> _hits = new List<Visual>();

        #region 基础部分

        protected override Visual GetVisualChild(int index)
        {
            return _eles[index];
        }

        protected override int VisualChildrenCount
        {
            get
            {
                return _eles.Count;
            }
        }

        public virtual void AddChild(Visual ele)
        {
            _eles.Add(ele);

            if (ele is UIElement)
            {
                this.Children.Add(ele as UIElement);
            }
            else if (ele is DrawingVisual)
            {
                AddVisualChild(ele);
                AddLogicalChild(ele);
            }
        }

        public virtual void RemoveChild(Visual ele)
        {
            _eles.Remove(ele);

            if (ele is UIElement)
            {
                this.Children.Remove(ele as UIElement);
            }
            else if (ele is DrawingVisual)
            {
                RemoveVisualChild(ele);
                RemoveLogicalChild(ele);
            }
        }

        public Visual GetVisual(Point point)
        {
            HitTestResult hitResult = VisualTreeHelper.HitTest(this, point);
            return hitResult.VisualHit as Visual;
        }

        private HitTestResultBehavior HitTestCallback(HitTestResult result)
        {
            GeometryHitTestResult geometryResult = (GeometryHitTestResult)result;
            DrawingVisual visual = result.VisualHit as DrawingVisual;

            if (visual != null && (geometryResult.IntersectionDetail == IntersectionDetail.FullyInside
                || geometryResult.IntersectionDetail == IntersectionDetail.Intersects))
            {
                _hits.Add(visual);
            }

            return HitTestResultBehavior.Continue;
        }

        public List<Visual> GetVisuals(System.Windows.Media.Geometry region)
        {
            _hits.Clear();

            GeometryHitTestParameters parameters = new GeometryHitTestParameters(region);
            HitTestResultCallback callback = new HitTestResultCallback(this.HitTestCallback);
            VisualTreeHelper.HitTest(this, null, callback, parameters);

            return _hits;
        }
        #endregion
    }
}
