using _1nicerTourPlanner.BusinessLayer.Helper;
using _1nicerTourPlanner.BusinessLayer.TourHandling;
using _1nicerTourPlanner.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace _1nicerTourPlanner.ViewModels
{
    public class ModifyTourVM : ViewModelBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ModifyTourHandler handler;
        private Tour currentTour;
        private Validator validator;
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
            handler = new ModifyTourHandler();
            CurrentTour = tour;
            validator = new Validator();
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
                /*if (!validator.IsAllowedInputExtended(CurrentTour.Description))
                {
                    MessageBox.Show("Please only use:\na-z A-Z Ää Öö Üü 0-9 -_.:,!?=");
                    log.Error("Modifying Tour failed - false input");
                }*/
                handler.ModifyTour(CurrentTour.TourID, CurrentTour.Name, CurrentTour.Description, CurrentTour.Distance);
                MessageBox.Show("Success!");
                log.Info("Modify tour");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
    }
}
