using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using _1nicerTourPlanner.BusinessLayer;
using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.ViewModels;

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
        DB db;
        public AddTourVM()
        {
            db = new DB();
            httpCon = new HTTPConnection();
            httpResp = new HTTPResponse();
            imageHandler = new ImageHandler();
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
            string response = httpCon.GetJsonResponse(NewStart, NewDestination);
            httpResp.SetJObject(response);
            string imagepath = imageHandler.SaveImage(httpResp.GetMapData(), NewName);
            NewDistance = float.Parse(httpResp.GetMapData().Distance);
            try
            {
                db.AddTour(NewName, NewDescription, NewDistance, NewStart, NewDestination, imagepath);
                MessageBox.Show("Success!");
                NewName = "";
                NewDescription = "";
                NewStart = "";
                NewDestination = "";
            }
            catch(Exception)
            {
                log.Error("Adding Tour failed");
            }
        }
        private void Clear(object commandParameter)
        {
            NewName = "";
            NewDescription = "";
            NewDistance = 0;
            NewStart = "";
            NewDestination = "";
        }
    }
}
