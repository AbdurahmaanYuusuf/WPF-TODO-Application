using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_TODO_Application.Commands;
using WPF_TODO_Application.Database;

namespace WPF_TODO_Application.ViewModels
{
    public class RemoveCardViewModel : ViewModelBase
    {
        private string _cardName;//= new Person();
        public string CardName
        {
            get { return _cardName; }
            set { _cardName = value; OnPropertyChanged(CardName); }
        }


        private ICommand removeCardCommand;
        public ICommand RemoveCardCommand
        {
            get
            {
                if (removeCardCommand == null)
                {
                    removeCardCommand = new RemoveCardCommand(RemoveCardExecute, CanReomoveCardExecute);
                }
                return removeCardCommand;
            }
            set
            {
                removeCardCommand = value;
            }
        }

        private bool CanReomoveCardExecute(object arg)
        {
            if (string.IsNullOrEmpty(CardName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void RemoveCardExecute(object obj)
        {
            DbServices.RemoveCard(CardName);
        }

        
        //public ICommand GoToMainWindowCommand { get; set;}

        public RemoveCardViewModel()
        {
            
            this.RemoveCardCommand = new RemoveCardCommand(RemoveCardExecute, CanReomoveCardExecute);
            //GoToMainWindowCommand = new GoToMainWindowCommand();
        }
    }
}
