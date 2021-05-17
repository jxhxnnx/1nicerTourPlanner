using _1nicerTourPlanner.BusinessLayer.Helper;
using _1nicerTourPlanner.BusinessLayer.LogHandling;
using _1nicerTourPlanner.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace _1nicerTourPlanner.ViewModels
{
    class AddLogVM : ViewModelBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private AddLogHandler handler;
        private Validator validator = new Validator();
        private ICommand clearCommand;
        private ICommand addLogCommand;
        public ICommand ClearCommand => clearCommand ??= new RelayCommand(Clear);
        public ICommand AddLogCommand => addLogCommand ??= new RelayCommand(AddLog);

        private Tour currentTour;
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

        public DateTime Date
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
                    RaisePropertyChangedEvent(nameof(Date));
                }
            }
        }
        public float Distance
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
                    RaisePropertyChangedEvent(nameof(Distance));
                }
            }
        }
        public float TotTime
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
                    RaisePropertyChangedEvent(nameof(TotTime));
                }
            }
        }
        public int TourID
        {
            get
            {
                return currentTour.TourID;
            }
        }
        public string Name
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
                    RaisePropertyChangedEvent(nameof(Name));
                }
            }
        }
        public string Report
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
                    RaisePropertyChangedEvent(nameof(Report));
                }
            }
        }
        public int Rating
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
                    RaisePropertyChangedEvent(nameof(Rating));
                }
            }
        }
        public bool Alone
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
                    RaisePropertyChangedEvent(nameof(Alone));
                }
            }
        }
        public string Vehicle
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
                    RaisePropertyChangedEvent(nameof(Vehicle));
                }
            }
        }
        public string Weather
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
                    RaisePropertyChangedEvent(nameof(Weather));
                }
            }
        }
        public string Traveller
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
                    RaisePropertyChangedEvent(nameof(Traveller));
                }
            }
        }
        public float Speed
        {
            get
            {
                if (Distance == 0 || TotTime == 0)
                {
                    return 0;
                }
                return (distance / totTime) * 60;
            }
        }

        public AddLogVM(Tour tour)
        {
            handler = new AddLogHandler();
            CurrentTour = tour;
        }


        private void Clear(object commandParameter)
        {
            ClearAll();
        }



        private void AddLog(object commandParameter)
        {
            try
            {
                if (Name == null || Report == null || Traveller == null || Vehicle == null || Weather == null)
                {
                    MessageBox.Show("Please fill everything");
                    log.Error("Adding Log failed - missing input");
                }
                else if (!validator.IsNumber(Distance.ToString()) || !validator.IsNumber(TotTime.ToString()))
                {
                    MessageBox.Show("Please only use:\n0-9 for Distance and Total Time");
                    log.Error("Adding Log failed - invalid input");
                }
                /*else if (!validator.IsAllowedInputExtended(Name) || !validator.IsAllowedInputExtended(Report)
                    || !validator.IsAllowedInputExtended(Weather) || !validator.IsAllowedInputExtended(Traveller)
                    || !validator.IsAllowedInputExtended(Vehicle))
                {
                    MessageBox.Show("Please only use:\na-z A-Z Ää Öö Üü 0-9 -_.:,!?=\nfor Name, Report, Weather, Traveller and Vehicle");
                    log.Error("Adding Log failed - invalid input");
                }*/
                else
                {
                    handler.AddLog(Date, Distance, TotTime, TourID, Name, Report, Rating, Alone, Vehicle, Weather, Traveller, Speed);
                    MessageBox.Show("Success!");
                    ClearAll();
                    log.Info("Adding Log");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public void ClearAll()
        {
            Distance = 0;
            TotTime = 0;
            Name = "";
            Report = "";
            Rating = 0;
            Alone = false;
            Vehicle = "";
            Weather = "";
            Traveller = "";
            Date = DateTime.Now;
        }


    }
}
