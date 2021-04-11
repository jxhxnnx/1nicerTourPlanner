using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using _1nicerTourPlanner.BusinessLayer;
using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.ViewModels;

namespace _1nicerTourPlanner.ViewModels
{
    class AddTourVM : ViewModelBase
    {
        private string newName;
        private string newDescription;
        private float newDistance;

        private ICommand addTourCommand;
        private ICommand clearCommand;
        public ICommand AddTourCommand => addTourCommand ??= new RelayCommand(AddTour);
        public ICommand ClearCommand => clearCommand ??= new RelayCommand(Clear);
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

        private void AddTour(object commandParameter)
        {
            DB db = new DB();
            db.AddTour(NewName, NewDescription, NewDistance);
            NewName = "Success";
            NewDescription = "";
            NewDistance = 0;
            
        }
        private void Clear(object commandParameter)
        {
            NewName = "";
            NewDescription = "";
            NewDistance = 0;

        }

        private ICommand closeWindowCommand;
        public ICommand CloseWindowCommand => closeWindowCommand ??= new RelayCommand(CloseWindow);

        private void CloseWindow(object commandParameter)
        {
            
        }
        
    }
}
