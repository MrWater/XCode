using XCode.Module.SimplePS.Action;
using XCode.Module.SimplePS.Common;
using XCode.Module.SimplePS.Common.Paint;
using XCode.Module.SimplePS.Geometry;
using XCode.Module.SimplePS.Geometry.GeometrySpecialAction;
using XCode.Module.SimplePS.Geometry.GeometrySpecialAction.Action;
using XCode.Module.SimplePS.Geometry.SpecialAction.Action;
using XCode.Module.SimplePS.Layer;
using XCode.Module.SimplePS.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace XCode.Module.SimplePS.Service
{
    /// <summary>
    /// 主要服务于MVVM中VM的具体服务
    /// 以及直接服务View层的服务, MVC的C
    /// </summary>
    internal class TemplateEditService
    {
        private TemplateEditViewModel _vm;

        /// <summary>
        /// 
        /// </summary>
        public Transaction Transaction { get; private set; }

        /// <summary>
        /// 当前绘制上下文
        /// </summary>
        public PaintContext PaintContext { get; private set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="vm"></param>
        public TemplateEditService(TemplateEditViewModel vm)
        {
            Transaction = new Transaction();
            PaintContext = new PaintContext();
            _vm = vm;
        }
        
        /// <summary>
        /// 增加图层
        /// </summary>
        /// <param name="layer"></param>
        public void AddLayer(LayerBase layer)
        {
            if (layer == null)
                return;

            PaintContext.LayerGroup.Add(layer);

            var Geometrys = layer.GetGeometries();
            if (Geometrys != null)
            {
                Geometrys.ForEach(m => PaintContext.Canvas.AddChild(m));
            }
        }

        /// <summary>
        /// 移除图层
        /// </summary>
        /// <param name="layers"></param>
        public void RemoveLayer(IList layers)
        {
            if (layers == null)
                return;
            
            foreach(LayerBase layer in layers)
            {
                var Geometrys = (layer as LayerBase).GetGeometries();
                if (Geometrys != null)
                {
                    Geometrys.ForEach(m => PaintContext.Canvas.RemoveChild(m));
                }

                PaintContext.LayerGroup.Remove(layer);
            }

            //TODO:事务提交删除
        }

        /// <summary>
        /// 锁定图层
        /// </summary>
        /// <param name="layers"></param>
        public void LockLayer(IList layers)
        {
            if (layers == null)
                return;

            foreach (LayerBase layer in layers)
            {
                layer.Editable = !layer.Editable;
            }
        }
        
        /// <summary>
        /// 注册按住Shift时的特殊行为
        /// </summary>
        public void RegisterShiftPressedAction()
        {
            var specialAction = SpecialActionPool.Default[typeof(Line)];
            if (specialAction != null)
            {
                specialAction.Add(DrawLineWithShiftAction.Instance);
            }

            specialAction = SpecialActionPool.Default[typeof(Circle)];
            if (specialAction != null)
            {
                specialAction.Add(DrawPolygonWithShiftAction.Instance);
            }

            specialAction = SpecialActionPool.Default[typeof(Geometry.Image)];
            if (specialAction != null)
            {
                specialAction.Add(DrawPolygonWithShiftAction.Instance);
            }

            specialAction = SpecialActionPool.Default[typeof(Rectangle)];
            if (specialAction != null)
            {
                specialAction.Add(DrawPolygonWithShiftAction.Instance);
            }

            specialAction = SpecialActionPool.Default[typeof(Triangle)];
            if (specialAction != null)
            {
                specialAction.Add(DrawPolygonWithShiftAction.Instance);
            }
        }

        /// <summary>
        /// 取消Shift操作的注册
        /// </summary>
        public void UnregisterShiftPressedAction()
        {
            var specialAction = SpecialActionPool.Default[typeof(Line)];
            if (specialAction != null)
            {
                specialAction.Remove(DrawLineWithShiftAction.Instance);
            }

            specialAction = SpecialActionPool.Default[typeof(Circle)];
            if (specialAction != null)
            {
                specialAction.Remove(DrawPolygonWithShiftAction.Instance);
            }

            specialAction = SpecialActionPool.Default[typeof(Geometry.Image)];
            if (specialAction != null)
            {
                specialAction.Remove(DrawPolygonWithShiftAction.Instance);
            }

            specialAction = SpecialActionPool.Default[typeof(Rectangle)];
            if (specialAction != null)
            {
                specialAction.Remove(DrawPolygonWithShiftAction.Instance);
            }

            specialAction = SpecialActionPool.Default[typeof(Triangle)];
            if (specialAction != null)
            {
                specialAction.Remove(DrawPolygonWithShiftAction.Instance);
            }
        }

        /// <summary>
        /// 上下文菜单的控制
        /// </summary>
        /// <returns></returns>
        public ContextMenu GetContextMenu()
        {
            ContextMenu menu = new ContextMenu();
            menu.Items.Add(new MenuItem() { Header = "固定" });
            menu.Items.Add(new Separator());

            if (PaintContext != null && PaintContext.OperationLayers != null)
            {
                //考虑目前一个图层一个图元 暂不多做处理
                if(PaintContext.OperationLayers.Count == 1)
                {
                    if(PaintContext.OperationLayers[0].GetGeometries()[0] is Line)
                        menu.Items.Add(new MenuItem() { Header = "测试_Line" });
                    if (PaintContext.OperationLayers[0].GetGeometries()[0] is Rectangle)
                        menu.Items.Add(new MenuItem() { Header = "测试_Rectangle" });
                    if (PaintContext.OperationLayers[0].GetGeometries()[0] is Circle)
                        menu.Items.Add(new MenuItem() { Header = "测试_Circle" });
                    if (PaintContext.OperationLayers[0].GetGeometries()[0] is Triangle)
                        menu.Items.Add(new MenuItem() { Header = "测试_Triangle" });
                }
            }

            return menu;
        }
    }
}
