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
    /// 图层接口
    /// </summary>
    internal interface ILayer : IRenderAction
    {
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; set; }

        bool IsHighlight { get; set; }

        bool Visible { get; set; }

        bool Editable { get; set; }

        void AddGeometry(GeometryBase Geometry);

        List<GeometryBase> GetGeometries();
    }
}
