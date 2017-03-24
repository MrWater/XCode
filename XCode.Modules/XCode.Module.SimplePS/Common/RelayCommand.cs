using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XCode.Module.SimplePS.Common
{
    internal class RelayCommand : ICommand
    {
        private System.Action _action;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(System.Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_action != null)
            {
                _action();
            }
        }
    }

    internal class RelayCommand<T> : ICommand
    {
        private Action<T> _action;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<T> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_action != null)
            {
                _action((T)parameter);
            }
        }
    }
}
