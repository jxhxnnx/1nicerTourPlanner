using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using _1nicerTourPlanner.ViewModels;
using System.Collections;
using _1nicerTourPlanner.BusinessLayer;
using System;
using _1nicerTourPlanner.BusinessLayer.LogHandling;

namespace _1nicerTourPlanner.ViewModels
{
    public class TourLogVM : ViewModelBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private TourDAO tourDAO;
        private Tour currentTour;
        private TourLogHandler handler;
        private string searchName;
        private ICommand searchCommand;
        private ICommand clearCommand;
        private ICommand modifyLogCommand;
        private ICommand deleteLogCommand;
        public ICommand ModifyLogCommand => modifyLogCommand ??= new RelayCommand(ModifyLog);
        public ICommand DeleteLogCommand => deleteLogCommand ??= new RelayCommand(DeleteLog);
        public ICommand SearchCommand => searchCommand ??= new RelayCommand(Search);
        public ICommand ClearCommand => clearCommand ??= new RelayCommand(Clear);
        private ObservableCollection<TourLog> logs = new ObservableCollection<TourLog>();
        private TourLog currentLog;
        public ObservableCollection<TourLog> Logs
        {
            get
            {
                return logs;
            }
            set
            {
                logs = value;
                RaisePropertyChangedEvent(nameof(Logs));
            }
        }
        public TourLog CurrentLog
        {
            get
            {
                return currentLog;
            }
            set
            {
                if (currentLog != value)
                {
                    currentLog = value;
                    RaisePropertyChangedEvent(nameof(CurrentLog));
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


        public List<TourLog> ListLog;
        public TourLogVM(Tour tour)
        {
            tourDAO = new TourDAO();
            currentTour = tour;
            handler = new TourLogHandler();
            InitListBox();
        }
        public TourLogVM()
        {
            //Eine Leiche aus vergangenen Zeiten
        }

        private void InitListBox()
        {
            Logs = new ObservableCollection<TourLog>();
            FillListBox();
        }

        private void FillListBox()
        {
            ListLog = tourDAO.GetLogs(currentTour.TourID);
            foreach (TourLog log in ListLog)
            {
                logs.Add(log);
            }
        }

        private void Search(object commandParameter)
        {
            IEnumerable foundLogs = handler.Search(SearchName, currentTour.TourID);
            Logs.Clear();
            foreach (TourLog item in foundLogs)
            {
                Logs.Add(item);
            }
        }

        private void Clear(object commandParameter)
        {
            Logs.Clear();
            SearchName = "";
            FillListBox();
        }

        
        private void ModifyLog(object commandParameter)
        {
            ModifyLogWindow modifyWindow = new ModifyLogWindow(CurrentLog);
            modifyWindow.Show();
            log.Info("Open Modify Log Window");
        }

        private void DeleteLog(object commandParameter)
        {
            try
            {
                handler.DeleteSingleLog(currentLog);
                Logs.Clear();
                FillListBox();
                log.Info("Delete Log");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
    }
}
