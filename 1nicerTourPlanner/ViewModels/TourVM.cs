using _1nicerTourPlanner.BusinessLayer;
using _1nicerTourPlanner.Models;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace _1nicerTourPlanner.ViewModels
{
    public class TourVM : ViewModelBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Tour currentTour;
        private string searchName;
        private TourHandler handler = new TourHandler();


        private ICommand searchCommand;
        private ICommand clearCommand;
        private ICommand newTourCommand;
        private ICommand deleteTourCommand;
        private ICommand modifyTourCommand;
        private ICommand copyTourCommand;
        private ICommand newLogCommand;
        private ICommand getLogsCommand;
        private ICommand exportTourCommand;
        private ICommand importTourCommand;
        private ICommand printTourCommand;
        public ICommand SearchCommand => searchCommand ??= new RelayCommand(Search);
        public ICommand ClearCommand => clearCommand ??= new RelayCommand(Clear);
        public ICommand NewTourCommand => newTourCommand ??= new RelayCommand(NewTour);
        public ICommand DeleteTourCommand => deleteTourCommand ??= new RelayCommand(DeleteTour);
        public ICommand GetLogsCommand => getLogsCommand ??= new RelayCommand(GetLogs);
        public ICommand ModifyTourCommand => modifyTourCommand ??= new RelayCommand(ModifyTour);
        public ICommand CopyTourCommand => copyTourCommand ??= new RelayCommand(CopyTour);
        public ICommand NewLogCommand => newLogCommand ??= new RelayCommand(NewLog);
        public ICommand ExportTourCommand => exportTourCommand ??= new RelayCommand(ExportTour);
        public ICommand ImportTourCommand => importTourCommand ??= new RelayCommand(ImportTour);
        public ICommand PrintTourCommand => printTourCommand ??= new RelayCommand(PrintTour);


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
            InitListBox();
        }

        private void InitListBox()
        {
            Tours = new ObservableCollection<Tour>();
            FillListBox();
        }

        private void FillListBox()
        {
            foreach (Tour item in handler.GetTours())
            {
                Tours.Add(item);
            }
        }

        private void Search(object commandParameter)
        {
            IEnumerable foundTours = handler.Search(SearchName);
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

        private void NewTour(object commandParameter)
        {
            NewTourWindow newWindow = new NewTourWindow();
            newWindow.Show();
            log.Info("Open New Tour Window");
        }

        private void DeleteTour(object commandParameter)
        {
            try
            {
                log.Info("Delete Tour");
                handler.DeleteTour(currentTour);
                Tours.Clear();
                FillListBox();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void GetLogs(object commandParameter)
        {
            log.Info("Open Log window");
            TourLogWindow logWindow = new TourLogWindow(CurrentTour);
            logWindow.Show();
        }

        private void ModifyTour(object commandParameter)
        {
            log.Info("Open modify tour window");
            ModifyTourWindow modifyWindow = new ModifyTourWindow(currentTour);
            modifyWindow.Show();
        }

        private void CopyTour(object commandParameter)
        {
            try
            {
                log.Info("Copy Tour");
                handler.CopyTour(currentTour);
                Tours.Clear();
                FillListBox();
                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void NewLog(object commandParameter)
        {
            log.Info("Open new log window");
            NewLogWindow newLogWindow = new NewLogWindow(CurrentTour);
            newLogWindow.Show();
        }

        private void ExportTour(object commandParameter)
        {
            CurrentTour.Logs = handler.GetLogs(CurrentTour.TourID);
            ExportHandler exportHandler = new ExportHandler();
            exportHandler.ExportTour(CurrentTour);
        }

        private void ImportTour(object commandParameter)
        {
            ImportHandler importHandler = new ImportHandler();
            importHandler.ImportTour();
            Tours.Clear();
            FillListBox();
        }

        private void PrintTour(object commandParameter)
        {
            log.Info("Open print window");
            CurrentTour.Logs = handler.GetLogs(CurrentTour.TourID);
            PrintWindow printWindow = new PrintWindow(CurrentTour);
            printWindow.Show();
        }
    }
}
