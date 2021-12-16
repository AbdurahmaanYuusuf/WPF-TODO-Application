using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TODO_Application.Commands
{
    public class MoveCardColumnCommand : CommandBase
    {
        public MoveCardColumnCommand(Action<object> executeAction, Func<object, bool> canExecute, bool canExecuteCache) : base(executeAction, canExecute, canExecuteCache)
        {
        }
    }
}
