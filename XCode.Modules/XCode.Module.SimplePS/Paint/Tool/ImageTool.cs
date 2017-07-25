using Microsoft.Win32;
using XCode.Module.SimplePS.Common.Paint;
using XCode.Module.SimplePS.Geometry;
using XCode.Module.SimplePS.Geometry.Action;
using XCode.Module.SimplePS.Geometry.GeometrySpecialAction;
using XCode.Module.SimplePS.Geometry.Style;
using XCode.Module.SimplePS.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XCode.Module.SimplePS.Paint.Tool
{
    /// <summary>
    /// 图片工具
    /// </summary>
    internal class ImageTool : PaintToolBase
    {
        /// <summary>
        /// 通知图层列表响应
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        private void NotifyLayerGroup(PaintContext context, PaintResult result)
        {
            if (result.PaintLayerType == PaintLayerType.New)
            {
                foreach (var layer in result.Layers)
                {
                    layer.Name = "未命名" + context.HistoryLayerCnt++.ToString();
                    context.LayerGroup.Insert(0, layer);

                    var geometrys = layer.GetGeometries();
                    if (geometrys != null)
                    {
                        geometrys.ForEach(m => context.Canvas.AddChild(m));
                    }
                }
            }
        }

        public override PaintResult BeginPaint(PaintContext context, Point beginPoint)
        {
            if (context == null)
                return null;

            if (_layers == null)
                _layers = new List<LayerBase>();
            else
                _layers.Clear();

            _paintContext = context;
            _geometry = null;

            SimpleLayer layer = new SimpleLayer();
            PaintResult result = new PaintResult();
            result.PaintLayerType = PaintLayerType.New;
            _geometry = new Image(new ImageStyle()
            {
                FirstPoint = beginPoint,
                SecondPoint = beginPoint
            }, new ImageAction());

            layer.AddGeometry(_geometry);
            _layers.Add(layer);
            result.Layers = _layers;

            context.OperationLayers.Clear();
            _layers.ForEach(m => context.OperationLayers.Add(m));

            NotifyLayerGroup(context, result);

            return result;
        }

        public override void Paint(Point currentPoint)
        {
            _geometry.Style.SecondPoint = currentPoint;
            _geometry.SpecialActionGroup.Clear();
            _geometry.SpecialActionGroup.AddRange(SpecialActionPool.Default[typeof(Image)]);
            _geometry.Refresh();
        }

        public override void EndPaint()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.CheckFileExists = true;
            dlg.CheckPathExists = true;
            dlg.Filter = "图片|*.png;*.jpeg;*.jpg;";

            if ((bool)dlg.ShowDialog())
            {
                ((_geometry as Image).Style as ImageStyle).ImageUri = new Uri(dlg.FileName);
            }
            else
            {
                if (_paintContext != null && _paintContext.OperationLayers != null)
                {
                    for (int i = 0; i < _paintContext.OperationLayers.Count; ++i)
                    {
                        _paintContext.OperationLayers[i].GetGeometries().ForEach(m => _paintContext.Canvas.RemoveChild(m));
                        _paintContext.LayerGroup.Remove(_paintContext.OperationLayers[i]);
                    }

                    _paintContext.OperationLayers.Clear();
                }
            }

            _geometry.SpecialActionGroup.Clear();

            if (_paintContext != null && _paintContext.OperationLayers != null)
            {
                for (int i = 0; i < _paintContext.OperationLayers.Count; ++i)
                {
                    _paintContext.OperationLayers[i].Refresh();
                }
            }
        }
    }
}
