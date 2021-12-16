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
        private ObservableCollection<ObservableCollection<Card>> _board;
        public ObservableCollection<ObservableCollection<Card>> Board

        {
            get { return _board; }
            set { _board = value; OnPropertyChanged("Board"); }
        }

        private ObservableCollection<Card> tODO_Cards;
        public ObservableCollection<Card> TODO_Cards

        {
            get { return tODO_Cards; }
            set { tODO_Cards = value; OnPropertyChanged("TODO_Cards"); }
        }

        private ObservableCollection<Card> iNPROGRESS_Cards;
        public ObservableCollection<Card> INPROGRESS_Cards

        {
            get { return iNPROGRESS_Cards; }
            set { iNPROGRESS_Cards = value; OnPropertyChanged("INPROGRESS_Cards"); }
        }
            
        private ObservableCollection<Card> dONE_Cards;
        public ObservableCollection<Card> DONE_Cards

        {
            get { return dONE_Cards; }
            set { dONE_Cards = value; OnPropertyChanged("DONE_Cards"); }
        }

        private ICommand showBoardCommand { get; set; }
        public ICommand ShowBoardCommand
        {
            get
            {
                if (showBoardCommand == null)
                {
                    showBoardCommand = new ShowBoardCommand(ShowBoardExecute, CanShowBoardExecute, false);
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

            //TODO_Cards = DbServices.GetAllCardsTODO();
            //INPROGRESS_Cards = DbServices.GetAllCardsINPROGRESS();
            //DONE_Cards = DbServices.GetAllCardsDONE();


            foreach (Card card in DbServices.GetAllCardsTODO())
            {
                TODO_Cards.Add(card);
            }

            foreach (Card card in DbServices.GetAllCardsINPROGRESS())
            {
                INPROGRESS_Cards.Add(card);
            }

            foreach (Card card in DbServices.GetAllCardsDONE())
            {
                DONE_Cards.Add(card);
            }
            
            
            /*Board.Add(TODO_Cards);
            Board.Add(INPROGRESS_Cards);
            Board.Add(DONE_Cards);*/
        }

        //public ICommand GoToMainWindowCommand { get; set; }

        public ShowBoardViewModel()
        {
            TODO_Cards = new ObservableCollection<Card>();
            INPROGRESS_Cards = new ObservableCollection<Card>();
            DONE_Cards = new ObservableCollection<Card>();
            //Board = new ObservableCollection<ObservableCollection<Card>>();
        }


    }
}
