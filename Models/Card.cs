using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TODO_Application.Models
{
    public class Card : INotifyPropertyChanged
    {
        private string cardName;
        public string CardName
        {
            get { return cardName; }
            set { cardName = value; OnPropertyChanged(CardName);}
        }
        

        private string cardContent;
        public string CardContent
        {
            get { return cardContent; }
            set { cardContent = value; OnPropertyChanged(CardContent); }
        }


        private string taskAppointee;
        public string TaskAppointee
        {
            get { return taskAppointee; }
            set { taskAppointee = value; OnPropertyChanged(TaskAppointee); }
        }

        
        private string cardSize;
        public string CardSize
        {
            get { return cardSize; }
            set { cardSize = value; OnPropertyChanged(CardSize); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

    }
}
