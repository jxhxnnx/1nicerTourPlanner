using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using _1nicerTourPlanner.BusinessLayer;
using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.Models;
using _1nicerTourPlanner.ViewModels;

namespace _1nicerTourPlanner.ViewModels
{
    public class TourVM : ViewModelBase
    {
        private ITourFactory tourFactory;
        private Tour currentTour;
        private string searchName;
        public DB db = new DB();

        private ICommand searchCommand;
        private ICommand clearCommand;
        public ICommand SearchCommand => searchCommand ??= new RelayCommand(Search);
        public ICommand ClearCommand => clearCommand ??= new RelayCommand(Clear);
        public ObservableCollection<Tour> Tours { get; set; }
        public ObservableCollection<TourLog> Logs { get; set; }
        public Tour CurrentTour
        {
            get
            {
                return currentTour;
            }
            set
            {
                if (currentTour != value)
                {
                    currentTour = value;
                    RaisePropertyChangedEvent(nameof(CurrentTour));
                }
            }
        }
        public string SearchName
        {
            get { return searchName; }
            set
            {
                if (searchName != value)
                {
                    searchName = value;
                    RaisePropertyChangedEvent(nameof(SearchName));
                }
            }
        }
        public TourVM()
        {
            tourFactory = TourFactory.GetInstance();
            InitListBox();
        }

        private void InitListBox()
        {
            Tours = new ObservableCollection<Tour>();
            FillListBox();
        }

        private void FillListBox()
        {
            foreach (Tour item in this.tourFactory.GetTours())
            {
                Tours.Add(item);
            }
        }

        private void Search(object commandParameter)
        {
            IEnumerable foundTours = this.tourFactory.Search(SearchName);
            Tours.Clear();
            foreach (Tour item in foundTours)
            {
                Tours.Add(item);
            }
        }
        private void Clear(object commandParameter)
        {
            Tours.Clear();
            SearchName = "";
            FillListBox();
        }

        private ICommand newTourCommand;
        public ICommand NewTourCommand => newTourCommand ??= new RelayCommand(NewTour);

        private void NewTour(object commandParameter)
        {
            NewTourWindow newWindow = new NewTourWindow();
            newWindow.Show();
        }

        private ICommand deleteTourCommand;
        public ICommand DeleteTourCommand => deleteTourCommand ??= new RelayCommand(DeleteTour);

        private void DeleteTour(object commandParameter)
        {
            db.DeleteTour(currentTour);
            Tours.Clear();
            FillListBox();
        }

        private ICommand getLogsCommand;
        public ICommand GetLogsCommand => getLogsCommand ??= new RelayCommand(GetLogs);

        private void GetLogs(object commandParameter)
        {
            if (currentTour != null)
            {
                TourLogWindow logWindow = new TourLogWindow(CurrentTour);
                logWindow.Show();
            }
            else
            {
                MessageBox.Show("Please choose a tour!");
            }
        }

        private ICommand modifyTourCommand;
        public ICommand ModifyTourCommand => modifyTourCommand ??= new RelayCommand(ModifyTour);

        private void ModifyTour(object commandParameter)
        {
            ModifyTourWindow modifyWindow = new ModifyTourWindow(CurrentTour);
            modifyWindow.Show();
        }

        private ICommand copyTourCommand;
        public ICommand CopyTourCommand => copyTourCommand ??= new RelayCommand(CopyTour);

        private void CopyTour(object commandParameter)
        {
            if (currentTour != null)
            {
                db.CopyTour(currentTour);
                Tours.Clear();
                FillListBox();
                MessageBox.Show("Success!");
            }
            else
            {
                MessageBox.Show("Please choose a tour!");
            }

        }

        private ICommand newLogCommand;
        public ICommand NewLogCommand => newLogCommand ??= new RelayCommand(NewLog);

        private void NewLog(object commandParameter)
        {
            if (currentTour != null)
            {
                NewLogWindow newLogWindow = new NewLogWindow(CurrentTour);
                newLogWindow.Show();
            }
            else
            {
                MessageBox.Show("Please choose a tour!");
            }

        }
    }
}
