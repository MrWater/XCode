using XCode.Module.SimplePS.Geometry;
using XCode.Module.SimplePS.Layer;
using XCode.Module.SimplePS.PaintTool;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XCode.Module.SimplePS.Common.Paint
{
    /// <summary>
    /// 绘制上下文
    /// </summary>
    internal class PaintContext
    {
        /// <summary>
        /// 鼠标状态
        /// </summary>
        public Cursor Cursor { get; private set; }

        /// <summary>
        /// 工具类型
        /// </summary>
        public ToolType ToolType { get; private set; }

        /// <summary>
        /// 画布
        /// </summary>
        public DrawingCanvas Canvas { get; set; }

        /// <summary>
        /// 绘制工具
        /// </summary>
        public PaintToolBase PaintTool { get; private set; }

        /// <summary>
        /// 当前操作图层
        /// </summary>
        public List<LayerBase> OperationLayers { get; private set; }

        private static readonly Dictionary<string, Cursor> _cursor;
        private static readonly Dictionary<string, ToolType> _toolType;
        private static readonly Dictionary<string, PaintToolBase> _paintTool;

        public PaintContext()
        {
            OperationLayers = new List<LayerBase>();
        }

        /// <summary>
        /// 更新上下文的鼠标、元素类型和绘制工具
        /// </summary>
        /// <param name="uid"></param>
        public void Update(string uid)
        {
            Cursor cursor = Cursors.Arrow;
            ToolType type = ToolType.None;
            PaintToolBase paintTool = null;

            if (_cursor.TryGetValue(uid, out cursor))
            {
            }

            if (_toolType.TryGetValue(uid, out type))
            {
            }

            if(_paintTool.TryGetValue(uid, out paintTool))
            {
            }

            Cursor = cursor;
            ToolType = type;
            PaintTool = paintTool;
        }

        /// <summary>
        /// 更新上下文的操作图层
        /// </summary>
        /// <param name="layers"></param>
        public void Update(IList layers)
        {
            if (layers == null)
                return;

            OperationLayers.Clear();

            foreach(var item in layers)
            {
                OperationLayers.Add(item as LayerBase);
            }
        }

        /// <summary>
        /// 注册所有工具的相应部分上下文
        /// </summary>
        static PaintContext()
        {
            _cursor = new Dictionary<string, Cursor>();
            _cursor["Tool_Drag"] = Cursors.Arrow;
            _cursor["Tool_Rectangle"] = Cursors.Cross;
            _cursor["Tool_Triangle"] = Cursors.Cross;
            _cursor["Tool_Image"] = Cursors.Cross;
            _cursor["Tool_QRCode"] = Cursors.Cross;
            _cursor["Tool_Circle"] = Cursors.Cross;
            _cursor["Tool_Text"] = Cursors.IBeam;
            _cursor["Tool_Line"] = Cursors.Cross;

            _toolType = new Dictionary<string, ToolType>();
            _toolType["Tool_Drag"] = ToolType.Drag;
            _toolType["Tool_Rectangle"] = ToolType.Rectangle;
            _toolType["Tool_Triangle"] = ToolType.Triangle;
            _toolType["Tool_Image"] = ToolType.Image;
            _toolType["Tool_QRCode"] = ToolType.QRCode;
            _toolType["Tool_Circle"] = ToolType.Circle;
            _toolType["Tool_Text"] = ToolType.Text;
            _toolType["Tool_Line"] = ToolType.Line;

            _paintTool = new Dictionary<string, PaintToolBase>();
            _paintTool["Tool_Line"] = new LineTool();
            _paintTool["Tool_Drag"] = new DragTool();
        }
    }
}
