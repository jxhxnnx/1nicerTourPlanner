using _1nicerTourPlanner.BusinessLayer;
using _1nicerTourPlanner.DataAccessLayer;
using System;
using System.Windows;
using System.Windows.Input;


namespace _1nicerTourPlanner.ViewModels
{
    class AddTourVM : ViewModelBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string newName;
        private string newStart;
        private string newDestination;
        private string newDescription;
        private float newDistance;
        public HTTPConnection httpCon;
        public HTTPResponse httpResp;
        public ImageHandler imageHandler;
        private AddTourHandler handler;
        private Validator validator;
        public AddTourVM()
        {
            handler = new AddTourHandler();
            httpCon = new HTTPConnection();
            httpResp = new HTTPResponse();
            imageHandler = new ImageHandler();
            validator = new Validator();
        }


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
        public string NewStart
        {
            get
            {
                return newStart;
            }
            set
            {
                if (newStart != value)
                {
                    newStart = value;
                    RaisePropertyChangedEvent(nameof(NewStart));
                }
            }
        }
        public string NewDestination
        {
            get
            {
                return newDestination;
            }
            set
            {
                if (newDestination != value)
                {
                    newDestination = value;
                    RaisePropertyChangedEvent(nameof(NewDestination));
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
            if (NewStart == null || NewDestination == null || NewDescription == null)
            {
                MessageBox.Show("Please fill everything!");
                log.Error("Adding Tour failed - missing input");
            }
            else if (!validator.IsAlphabet(NewStart) || !validator.IsAlphabet(NewDestination))
            {
                MessageBox.Show("Please only use a-z A-Z\nfor Start and Destination!");
                log.Error("Adding Tour failed - false input");
            }
            else if (!validator.IsAllowedInput(NewName))
            {
                MessageBox.Show("Please only use:\na-z A-Z 0-9 -_.:,!?=\n for Name and Description additionally Ää Öö Üü");
                log.Error("Adding Tour failed - false input");
            }
            else if (NameExists(NewName))
            {
                MessageBox.Show("Please choose another name! Name must be unique!");
                log.Error("Adding Tour failed - name already exists");
            }
            else
            {
                string response = httpCon.GetJsonResponse(NewStart, NewDestination);
                httpResp.SetJObject(response);
                string imagepath = imageHandler.GetImagePath(httpResp.GetMapData(), NewName);
                NewDistance = float.Parse(httpResp.GetMapData().Distance);
                try
                {
                    handler.AddTour(NewName, NewDescription, NewDistance, NewStart, NewDestination, imagepath);
                    MessageBox.Show("Success!");
                    ClearAll();
                    log.Info("Add tour");
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }
            }

        }



        private void Clear(object commandParameter)
        {
            ClearAll();
        }

        public void ClearAll()
        {
            NewName = "";
            NewDescription = "";
            NewDistance = 0;
            NewStart = "";
            NewDestination = "";
        }

        private bool NameExists(string name)
        {
            if (handler.NameExists(name))
            {
                return true;
            }
            return false;
        }

    }
}


