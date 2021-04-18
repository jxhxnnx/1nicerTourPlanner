using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using _1nicerTourPlanner.ViewModels;
using System.Windows;

namespace _1nicerTourPlanner.ViewModels
{
    class AddLogVM : ViewModelBase
    {
        
        public DB db;
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
                return (distance/totTime)*60;
            }
        }

        public AddLogVM(Tour tour)
        {
            db = new DB();
            CurrentTour = tour;
        }

        private ICommand clearCommand;
        public ICommand ClearCommand => clearCommand ??= new RelayCommand(Clear);

        private void Clear(object commandParameter)
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

        private ICommand addLogCommand;
        public ICommand AddLogCommand => addLogCommand ??= new RelayCommand(AddLog);

        private void AddLog(object commandParameter)
        {
            db.AddLog(Date, Distance, TotTime, TourID, Name, Report, Rating, Alone, Vehicle, Weather, Traveller, Speed);
            MessageBox.Show("Success!");
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
