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
            set { cardName = value; OnPropertyChanged(cardName);}
        }
        

        private string cardContent;
        public string CardContent
        {
            get { return cardContent; }
            set { cardContent = value; OnPropertyChanged(cardContent); }
        }


        private string taskAppointee;
        public string TaskAppointee
        {
            get { return taskAppointee; }
            set { taskAppointee = value; OnPropertyChanged(taskAppointee); }
        }

        
        private string cardSize;
        public string CardSize
        {
            get { return cardSize; }
            set { cardSize = value; OnPropertyChanged(cardSize); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

    }
}
