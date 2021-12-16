using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_TODO_Application.Commands
{
    public class RemoveCardCommand : CommandBase
    {
        public RemoveCardCommand(Action<object> executeAction, Func<object, bool> canExecute, bool canExecuteCache) 
            : base(executeAction, canExecute, canExecuteCache)
        {
        }
    }
}
