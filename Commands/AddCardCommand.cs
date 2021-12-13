using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TODO_Application.Models;
using WPF_TODO_Application.ViewModels;

namespace WPF_TODO_Application.Commands
{
    public class AddCardCommand : CommandBase
    {
        public AddCardCommand(Action<object> executeAction, Func<object, bool> canExecute)
            : base(executeAction, canExecute)
        {

        }
    }
}
