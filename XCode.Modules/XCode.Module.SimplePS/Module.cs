using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using XCode.Framework.Module;
using XCode.Module.SimplePS.View;

namespace XCode.Module.SimplePS
{
    public class Module : ModuleBase
    {
        private TemplateEditView _view;

        public Module() :
            base()
        {
            _view = new TemplateEditView();
        }

        public override UserControl Entry
        {
            get
            {
                return _view;
            }
        }

        public override string Name { get; set; }

        public override Window Owner { get; set; }

        //public override MessageResult MessageFunc(IMessage message)
        //{
        //    switch(message)
        //}
    }
}
