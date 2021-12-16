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
    public class MoveCardViewModel : ViewModelBase
    {
        private string _cardName;
        public string CardName
        {
            get { return _cardName; }
            set { _cardName = value; OnPropertyChanged("CardName"); }
        }

        private String columnToMoveCardTo;

        public string ColumnToMoveCardTo
        {
            get { return columnToMoveCardTo; }
            set { columnToMoveCardTo = value; OnPropertyChanged("ColumnToMoveCardTo");}
        }

        private ICommand moveCardColumnCommand { get; set; }
        public ICommand MoveCardColumnCommand
        {
            get
            {
                if (moveCardColumnCommand == null)
                {
                    moveCardColumnCommand = new MoveCardColumnCommand(MoveCardColumnExecute, CanMoveCardColumnExecute,false);
                }
                return moveCardColumnCommand;
            }
            set
            {
                moveCardColumnCommand = value;
            }
        }

        private bool CanMoveCardColumnExecute(object arg)
        {
            if (string.IsNullOrEmpty(CardName) &&
                string.IsNullOrEmpty(columnToMoveCardTo))
            {
                return false;
            }
            
            return true;
        }

        private void MoveCardColumnExecute(object obj)
        {
            DbServices.UpdateCardColumn(CardName, columnToMoveCardTo);
        }


        //public ICommand GoToMainWindowCommand { get; set;}

        public MoveCardViewModel()
        {

            //this.MoveCardColumnCommand = new MoveCardColumnCommand(MoveCardColumnExecute, CanMoveCardColumnExecute);
            //GoToMainWindowCommand = new GoToMainWindowCommand();
        }
    }
}