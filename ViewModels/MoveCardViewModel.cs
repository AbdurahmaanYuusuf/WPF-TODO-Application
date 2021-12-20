using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_TODO_Application.Commands;
using WPF_TODO_Application.Database;
using WPF_TODO_Application.Models;
using Card = WPF_TODO_Application.Database.Card;

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

        private Card card_found;
        public Card Card_found
        {
            get { return card_found; }
            set { card_found = value; OnPropertyChanged("Card_found"); }
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
                    moveCardColumnCommand = new CommandBase(MoveCardColumnExecute, CanMoveCardColumnExecute,false);
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
            if (!string.IsNullOrEmpty(CardName) &&
                !string.IsNullOrEmpty(columnToMoveCardTo))
            {
                return true;
            }
            
            return false;
        }

        private void MoveCardColumnExecute(object obj)
        {
            DbServices.UpdateCardColumn(CardName, columnToMoveCardTo);
        }


        private ICommand searchCardCommand { get; set; }
        public ICommand SearchCardCommand
        {
            get
            {
                if (searchCardCommand == null)
                {
                    searchCardCommand = new CommandBase(SearchCardExecute, CanSearchCardExecute, false);
                }
                return searchCardCommand;
            }
            set
            {
                searchCardCommand = value;
            }
        }

        private bool CanSearchCardExecute(object arg)
        {
            return true;
        }

        private void SearchCardExecute(object obj)
        {
            
            if (DbServices.GetCard(CardName) != null)
            {
                Card_found = DbServices.GetCard(CardName);
            }
            else
            {
                Card_found = new()
                {
                    CardName="NO Card Was Found!",
                    CardContent= "NO Card Was Found! Please type the card's name correctly.",
                    CardSize="",
                    TaskAppointee=""
                };
            }
        }

        public MoveCardViewModel()
        {
            Card Card_found = new();
        }
    }
}