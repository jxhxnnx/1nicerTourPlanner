using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using _1nicerTourPlanner.ViewModels;
using _1nicerTourPlanner.BusinessLayer;
using System.Windows;

namespace _1nicerTourPlanner.ViewModels
{
    public class ModifyTourVM : ViewModelBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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

        private string newName;
        private string newDescription;
        private float newDistance;
        public string NewName
        {
            get
            {
                return newName;
            }
            set
            {
                if (newName != value)
                {
                    newName = value;
                    RaisePropertyChangedEvent(nameof(NewName));
                }
            }
        }
        public string NewDescription
        {
            get
            {
                return newDescription;
            }
            set
            {
                if (newDescription != value)
                {
                    newDescription = value;
                    RaisePropertyChangedEvent(nameof(NewDescription));
                }
            }
        }
        public float NewDistance
        {
            get
            {
                return newDistance;
            }
            set
            {
                if (newDistance != value)
                {
                    newDistance = value;
                    RaisePropertyChangedEvent(nameof(NewDistance));
                }
            }
        }
        
        public ModifyTourVM(Tour tour)
        {
            db = new DB();
            CurrentTour = tour;
        }
        /*public ModifyTourVM()
        {

        }*/

        private ICommand modifyTourCommand;
        public ICommand ModifyTourCommand => modifyTourCommand ??= new RelayCommand(ModifyTour);

        private void ModifyTour(object commandParameter)
        {
            try
            {
                db.ModifyTour(CurrentTour.TourID, CurrentTour.Name, CurrentTour.Description, CurrentTour.Distance);
                MessageBox.Show("Success!");
            }
            catch(Exception)
            {
                log.Error("Modifying Tour failed");
            }
            
        }
    }
}
