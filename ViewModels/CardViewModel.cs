using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TODO_Application.Models;

namespace WPF_TODO_Application.ViewModels
{
    public class CardViewModel : ViewModelBase, INotifyPropertyChanged
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
            set { _board = value; OnPropertyChanged("Persons"); }
        }

    }
}
