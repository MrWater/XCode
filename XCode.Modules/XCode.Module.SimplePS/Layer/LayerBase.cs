using XCode.Module.SimplePS.Common;
using XCode.Module.SimplePS.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Module.SimplePS.Layer
{
    /// <summary>
    /// 图层抽象类
    /// </summary>
    internal abstract class LayerBase : ObservableObject, ILayer
    {
        private List<GeometryBase> _geometries;
        private bool _visible;

        /// <summary>
        /// 显隐
        /// </summary>
        public bool Visible
        {
            get { return _visible; }
            set
            {
                if (_visible == value)
                    return;

                _visible = value;
                
                if(value == true)
                {
                    Refresh();
                }
                else
                {
                    Hide();
                }

                RaisePropertyChanged("Visible");
            }
        }

        private bool _editable;
        /// <summary>
        /// 是否可编辑
        /// </summary>
        public bool Editable
        {
            get { return _editable; }
            set
            {
                if (_editable == value)
                    return;

                _editable = value;
                RaisePropertyChanged("Editable");
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        public bool IsHighlight { get; set; }

        protected LayerBase()
        {
            Editable = true;
            Visible = true;
            _geometries = new List<GeometryBase>();
            IsHighlight = false;
        }

        public virtual void Render()
        {
            if(_geometries != null)
            {
                _geometries.ForEach(m => m.Render());
            }
        }

        public virtual void Refresh()
        {
            if (_geometries != null)
            {
                _geometries.ForEach(m => m.Refresh());
            }
        }

        public void AddGeometry(GeometryBase Geometry)
        {
            if (_geometries != null)
            {
                _geometries.Add(Geometry);
            }
        }

        public List<GeometryBase> GetGeometries()
        {
            return _geometries;
        }

        public void Hide()
        {
            if (_geometries != null)
            {
                _geometries.ForEach(m =>
                {
                    m.Hide();
                });
            }
        }

        public void Highlight()
        {
            if (_geometries != null)
            {
                _geometries.ForEach(m =>
                {
                    m.Highlight();
                });
            }
        }

        public void Move(double offsetX, double offsetY)
        {
            if(_geometries != null)
            {
                _geometries.ForEach(m => m.Move(offsetX, offsetY));
            }
        }

        public void ResetState()
        {
            if (_geometries != null)
            {
                _geometries.ForEach(m => m.ResetState());
            }
        }
    }
}
