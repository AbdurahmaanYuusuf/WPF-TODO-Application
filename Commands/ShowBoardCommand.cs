using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TODO_Application.Commands
{
    public class ShowBoardCommand : CommandBase
    {
        public ShowBoardCommand(Action<object> executeAction, Func<object, bool> canExecute, bool canExecuteCache) :
            base(executeAction, canExecute, canExecuteCache)
        {
        }
    }
}
