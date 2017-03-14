using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using XCode.Framework.Module;
using XCode.Module.ChickenSoup.Views;

namespace XCode.Module.ChickenSoup
{
    public class Module : ModuleBase
    {
        private MainView _view;

        public Module()
        {
            _view = new MainView();
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
    }
}
