using XCode.Module.SimplePS.Action;
using XCode.Module.SimplePS.Common;
using XCode.Module.SimplePS.Common.Paint;
using XCode.Module.SimplePS.Layer;
using XCode.Module.SimplePS.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Module.SimplePS.Service
{
    internal class TemplateEditService
    {
        private TemplateEditViewModel _vm;

        public LayerList LayerList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Transaction Transaction { get; private set; }

        /// <summary>
        /// 当前绘制上下文
        /// </summary>
        public PaintContext PaintContext { get; private set; }

        public TemplateEditService(TemplateEditViewModel vm)
        {
            Transaction = new Transaction();
            PaintContext = new PaintContext();
            LayerList = new LayerList();
            _vm = vm;
        }
        
        public void AddLayer(LayerBase layer)
        {
            if (layer == null)
                return;

            LayerList.Add(layer);

            var Geometrys = layer.GetGeometrys();
            if (Geometrys != null)
            {
                Geometrys.ForEach(m => PaintContext.Canvas.AddChild(m));
            }
        }

        public void RemoveLayer(IList layers)
        {
            if (layers == null)
                return;
            
            foreach(LayerBase layer in layers)
            {
                var Geometrys = (layer as LayerBase).GetGeometrys();
                if (Geometrys != null)
                {
                    Geometrys.ForEach(m => PaintContext.Canvas.RemoveChild(m));
                }

                LayerList.Remove(layer);
            }

            //TODO:事务提交删除
        }

        public void LockLayer(IList layers)
        {
            if (layers == null)
                return;

            foreach (LayerBase layer in layers)
            {
                layer.Editable = !layer.Editable;
            }
        }
    }
}
