using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_TODO_Application.Commands;
using WPF_TODO_Application.Database;
using WPF_TODO_Application.Models;
using Card = WPF_TODO_Application.Models.Card;

namespace WPF_TODO_Application.ViewModels
{
    public class AddCardViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private Card _card;//= new Person();
        public Card Card
        {
            get { return _card; }
            set { _card = value; OnPropertyChanged("Card"); }
        }

        private ObservableCollection<Card> _board;
        public ObservableCollection<Card> Board

        {
            get { return _board; }
            set { _board = value; OnPropertyChanged("Board"); }
        }

        private ICommand addCardCommand { get; set; }
        public ICommand AddCardCommand
        {
            get
            {
                if (addCardCommand == null)
                {
                    addCardCommand = new CommandBase(AddCardExecute, CanAddCardExecute, false);
                }
                return addCardCommand;
            }
            set
            {
                addCardCommand = value;
            }
        }

        private bool CanAddCardExecute(object arg)
        {
            if (string.IsNullOrEmpty(Card.CardName)   ||
                string.IsNullOrEmpty(Card.CardContent)||
                string.IsNullOrEmpty(Card.CardSize)   ||
                string.IsNullOrEmpty(Card.TaskAppointee))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void AddCardExecute(object obj)
        {
            Database.Card DBCard = new Database.Card()
            {
                CardName = Card.CardName,
                CardContent = Card.CardContent,
                TaskAppointee = Card.TaskAppointee,
                CardSize = Card.CardSize,
                BoardColumn = "TODO"
            };
            DbServices.AddCard(DBCard);
        }


        public AddCardViewModel()
        {
            Card = new Card();
            Board = new ObservableCollection<Card>();
        }
        
    }
}