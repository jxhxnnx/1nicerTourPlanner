using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using _1nicerTourPlanner.ViewModels;
using _1nicerTourPlanner.BusinessLayer;

namespace _1nicerTourPlanner.ViewModels
{
    public class ModifyLogVM : ViewModelBase
    {
        private TourLog currentLog;
        private ModifyLogHandler handler;
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
        public ModifyLogVM(TourLog log)
        {
            CurrentLog = log;
            handler = new ModifyLogHandler();
        }
        private DateTime date = DateTime.Now;
        private float distance;
        private float totTime;
        private string name;
        private string report;
        private int rating;
        private bool alone;
        private string vehicle;
        private string weather;
        private string traveller;

        public DateTime NewDate
        {
            get
            {
                return date;
            }
            set
            {
                if (date != value)
                {
                    date = value;
                    RaisePropertyChangedEvent(nameof(NewDate));
                }
            }
        }
        public float NewDistance
        {
            get
            {
                return distance;
            }
            set
            {
                if (distance != value)
                {
                    distance = value;
                    RaisePropertyChangedEvent(nameof(NewDistance));
                }
            }
        }
        public float NewTotTime
        {
            get
            {
                return totTime;
            }
            set
            {
                if (totTime != value)
                {
                    totTime = value;
                    RaisePropertyChangedEvent(nameof(NewTotTime));
                }
            }
        }
        public int NewTourID
        {
            get
            {
                return currentLog.TourID;
            }
        }
        public string NewName
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChangedEvent(nameof(NewName));
                }
            }
        }
        public string NewReport
        {
            get
            {
                return report;
            }
            set
            {
                if (report != value)
                {
                    report = value;
                    RaisePropertyChangedEvent(nameof(NewReport));
                }
            }
        }
        public int NewRating
        {
            get
            {
                return rating;
            }
            set
            {
                if (rating != value)
                {
                    rating = value;
                    RaisePropertyChangedEvent(nameof(NewRating));
                }
            }
        }
        public bool NewAlone
        {
            get
            {
                return alone;
            }
            set
            {
                if (alone != value)
                {
                    alone = value;
                    RaisePropertyChangedEvent(nameof(NewAlone));
                }
            }
        }
        public string NewVehicle
        {
            get
            {
                return vehicle;
            }
            set
            {
                if (vehicle != value)
                {
                    vehicle = value;
                    RaisePropertyChangedEvent(nameof(NewVehicle));
                }
            }
        }
        public string NewWeather
        {
            get
            {
                return weather;
            }
            set
            {
                if (weather != value)
                {
                    weather = value;
                    RaisePropertyChangedEvent(nameof(NewWeather));
                }
            }
        }
        public string NewTraveller
        {
            get
            {
                return traveller;
            }
            set
            {
                if (traveller != value)
                {
                    traveller = value;
                    RaisePropertyChangedEvent(nameof(NewTraveller));
                }
            }
        }
        public float NewSpeed
        {
            get
            {
                if (CurrentLog.Distance == 0 || CurrentLog.TotalTime == 0)
                {
                    return 0;
                }
                return (CurrentLog.Distance / CurrentLog.TotalTime) * 60;
            }
        }

        private ICommand modifyLogCommand;
        public ICommand ModifyLogCommand => modifyLogCommand ??= new RelayCommand(ModifyLog);

        private void ModifyLog(object commandParameter)
        {
            TourLog log = new TourLog()
            {
                Name = CurrentLog.Name,
                Distance = CurrentLog.Distance,
                Date = CurrentLog.Date,
                Report = CurrentLog.Report,
                Rating = CurrentLog.Rating,
                TotalTime = CurrentLog.TotalTime,
                Alone = CurrentLog.Alone,
                Vehicle = CurrentLog.Vehicle,
                Weather = CurrentLog.Weather,
                Traveller = CurrentLog.Traveller,
                Speed = CurrentLog.Speed,
                TourID = CurrentLog.TourID,
                logID = CurrentLog.logID
            };
            handler.ModifyLog(log);
        }
    }
}
