using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace XCode.Module.SimplePS.Geometry
{
    /// <summary>
    /// 矢量Geometry
    /// </summary>
    internal abstract class VectorGeometryBase : GeometryBase
    {
        protected VectorGeometryBase()
            : base()
        {
            this.VisualBitmapScalingMode = BitmapScalingMode.Fant;
            this.VisualTextHintingMode = TextHintingMode.Auto;
            this.VisualTextRenderingMode = TextRenderingMode.Auto;
        }
    }
}
