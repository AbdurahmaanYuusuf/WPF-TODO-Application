using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_TODO_Application.Commands;
using WPF_TODO_Application.Database;

namespace WPF_TODO_Application.ViewModels
{
    public class ShowBoardViewModel : ViewModelBase
    {
        private ObservableCollection<Card> _board;
        public ObservableCollection<Card> Board

        {
            get { return _board; }
            set { _board = value; OnPropertyChanged("Persons"); }
        }

        List<Card> TODO_Cards = new();
        List<Card> INPROGRESS_Cards = new();
        List<Card> DONE_Cards = new();

        private ICommand showBoardCommand;
        public ICommand ShowBoardCommand
        {
            get
            {
                if (showBoardCommand == null)
                {
                    showBoardCommand = new ShowBoardCommand(ShowBoardExecute, CanShowBoardExecute);
                }
                return showBoardCommand;
            }
            set
            {
                showBoardCommand = value;
            }
        }

        private bool CanShowBoardExecute(object arg)
        {
                return true;
        }

        private void ShowBoardExecute(object obj)
        {
            
            //display all cards in their corresponding columns.
            DbServices.GetAllCardsTODO();
            DbServices.GetAllCardsINPROGRESS();
            DbServices.GetAllCardsDONE();
        }

        //public ICommand GoToMainWindowCommand { get; set; }

        public ShowBoardViewModel()
        {
            Board = new ObservableCollection<Card>();

            this.ShowBoardCommand = new AddCardCommand(ShowBoardExecute, CanShowBoardExecute);
            //GoToMainWindowCommand = new GoToMainWindowCommand();
        }


    }
}
