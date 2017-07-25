using XCode.Module.SimplePS.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Module.SimplePS.Common.Paint
{
    /// <summary>
    /// 绘制的结果
    /// </summary>
    internal class PaintResult
    {
        public PaintLayerType PaintLayerType { get; set; }
        public List<LayerBase> Layers { get; set; }

        public PaintResult()
        {
            Layers = new List<LayerBase>();
        }
    }

    /// <summary>
    /// 绘制的图层类型
    /// </summary>
    internal enum PaintLayerType
    {
        None,
        Original,//原图层进行绘制
        New//新增图层进行绘制
    }
}
