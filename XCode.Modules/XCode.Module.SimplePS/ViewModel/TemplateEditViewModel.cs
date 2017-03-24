using XCode.Module.SimplePS.Common;
using XCode.Module.SimplePS.Layer;
using XCode.Module.SimplePS.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XCode.Module.SimplePS.ViewModel
{
    /// <summary>
    /// 模板编辑ViewModel
    /// </summary>
    internal class TemplateEditViewModel
    {
        public TemplateEditService Service { get; private set; }

        /// <summary>
        /// 删除图层命令
        /// </summary>
        public ICommand RemoveLayerCommand
        {
            get { return new RelayCommand<IList>(Service.RemoveLayer); }
        }

        public ICommand LockLayerCommand
        {
            get { return new RelayCommand<IList>(Service.LockLayer); }
        }

        public TemplateEditViewModel()
        {


            Service = new TemplateEditService(this);
        }
    }
}
