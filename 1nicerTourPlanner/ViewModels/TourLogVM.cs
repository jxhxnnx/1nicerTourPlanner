using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections;
using _1nicerTourPlanner.Models;
using _1nicerTourPlanner.DataAccessLayer;
using System.Collections.ObjectModel;
using System.Windows.Input;
using _1nicerTourPlanner.ViewModels;

namespace _1nicerTourPlanner.ViewModels
{
    public class TourLogVM : ViewModelBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private TourDAO tourDAO;
        private ObservableCollection<TourLog> logs = new ObservableCollection<TourLog>();
        public ObservableCollection<TourLog> Logs
        {
            get{
                return logs;
            }
            set
            {
                logs = value;
                RaisePropertyChangedEvent(nameof(Logs));
            }
        }

        public List<TourLog> ListLog;
        public TourLogVM(Tour tour)
        {
            tourDAO = new TourDAO();
            ListLog = tourDAO.GetLogs(tour.TourID);
            foreach (TourLog log in ListLog)
            {
                logs.Add(log);
            }
        }
        public TourLogVM()
        {
            //Eine Leiche aus vergangenen Zeiten
        }
    }
}
