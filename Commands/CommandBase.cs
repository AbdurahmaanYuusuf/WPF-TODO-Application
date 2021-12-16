using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_TODO_Application.Commands
{
    public class CommandBase : ICommand
    {
        Action<object> executeAction;
        Func<object, bool> canExecute;
        bool canExecuteCache;

        //public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            executeAction(parameter);
        }
        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
            {
                return true;
            }
            else
            {
                return canExecute(parameter);
            }
        }
        
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public CommandBase(Action<object> executeAction, Func<object, bool> canExecute,bool canExecuteCache)
        {
            this.executeAction = executeAction;
            this.canExecute = canExecute;
            this.canExecuteCache = canExecuteCache;
        }

    }

}
