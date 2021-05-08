using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Input;
using _1nicerTourPlanner.BusinessLayer;
using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.Models;
using _1nicerTourPlanner.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace _1nicerTourPlanner.ViewModels
{
    public class TourVM : ViewModelBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ITourFactory tourFactory;
        private Tour currentTour;
        private string searchName;
        public DB db = new DB();
        public HTTPConnection httpCon;
        public HTTPResponse httpResp;
        public ImageHandler imageHandler;

        private ICommand searchCommand;
        private ICommand clearCommand;
        public ICommand SearchCommand => searchCommand ??= new RelayCommand(Search);
        public ICommand ClearCommand => clearCommand ??= new RelayCommand(Clear);
        public ObservableCollection<Tour> Tours { get; set; }
        public ObservableCollection<TourLog> Logs { get; set; }
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
        public TourVM()
        {
            tourFactory = TourFactory.GetInstance();
            InitListBox();
        }

        private void InitListBox()
        {
            Tours = new ObservableCollection<Tour>();
            FillListBox();
        }

        private void FillListBox()
        {
            foreach (Tour item in this.tourFactory.GetTours())
            {
                Tours.Add(item);
            }
        }

        private void Search(object commandParameter)
        {
            IEnumerable foundTours = this.tourFactory.Search(SearchName);
            Tours.Clear();
            foreach (Tour item in foundTours)
            {
                Tours.Add(item);
            }
        }
        private void Clear(object commandParameter)
        {
            Tours.Clear();
            SearchName = "";
            FillListBox();
        }

        private ICommand newTourCommand;
        public ICommand NewTourCommand => newTourCommand ??= new RelayCommand(NewTour);

        private void NewTour(object commandParameter)
        {
            NewTourWindow newWindow = new NewTourWindow();
            newWindow.Show();
        }

        private ICommand deleteTourCommand;
        public ICommand DeleteTourCommand => deleteTourCommand ??= new RelayCommand(DeleteTour);

        private void DeleteTour(object commandParameter)
        {
            try
            {
                db.DeleteTour(currentTour);
                Tours.Clear();
                FillListBox();
            }
            catch (Exception)
            {
                log.Error("Deleting Tour failed");
            }


        }

        private ICommand getLogsCommand;
        public ICommand GetLogsCommand => getLogsCommand ??= new RelayCommand(GetLogs);

        private void GetLogs(object commandParameter)
        {
            TourLogWindow logWindow = new TourLogWindow(CurrentTour);
            logWindow.Show();
        }

        private ICommand modifyTourCommand;
        public ICommand ModifyTourCommand => modifyTourCommand ??= new RelayCommand(ModifyTour);

        private void ModifyTour(object commandParameter)
        {
            ModifyTourWindow modifyWindow = new ModifyTourWindow(currentTour);
            modifyWindow.Show();
        }

        private ICommand copyTourCommand;
        public ICommand CopyTourCommand => copyTourCommand ??= new RelayCommand(CopyTour);

        private void CopyTour(object commandParameter)
        {
            try
            {
                db.CopyTour(currentTour);
                Tours.Clear();
                FillListBox();
                MessageBox.Show("Success!");
            }
            catch(Exception)
            {
                log.Error("Copy Tour failed");
            }
        }

        private ICommand newLogCommand;
        public ICommand NewLogCommand => newLogCommand ??= new RelayCommand(NewLog);

        private void NewLog(object commandParameter)
        {
            NewLogWindow newLogWindow = new NewLogWindow(CurrentTour);
            newLogWindow.Show();
        }

        private ICommand exportTourCommand;
        public ICommand ExportTourCommand => exportTourCommand ??= new RelayCommand(ExportTour);

        private void ExportTour(object commandParameter)
        {
            TourDAO tourDAO = new TourDAO();
            CurrentTour.Logs = tourDAO.GetLogs(CurrentTour.TourID);
            string JSONresult = JsonConvert.SerializeObject(CurrentTour);
            string folderPath = ConfigurationManager.AppSettings["ExportFolderPath"].ToString();
            string exportPath = folderPath + "\\" + CurrentTour.Name + ".json";
            try
            {
                if (File.Exists(exportPath))
                {
                    File.Delete(exportPath);
                    using (var tw = new StreamWriter(exportPath, true))
                    {
                        tw.WriteLine(JSONresult.ToString());
                        tw.Close();
                    }
                }
                else if (!File.Exists(exportPath))
                {
                    using (var tw = new StreamWriter(exportPath, true))
                    {
                        tw.WriteLine(JSONresult.ToString());
                        tw.Close();
                    }
                }
                MessageBox.Show("Success");
            }
            catch(Exception)
            {
                log.Error("Exporting Tour failed");
            }
            
        }

        private ICommand importTourCommand;
        public ICommand ImportTourCommand => importTourCommand ??= new RelayCommand(ImportTour);

        private void ImportTour(object commandParameter)
        {
            httpCon = new HTTPConnection();
            httpResp = new HTTPResponse();
            imageHandler = new ImageHandler();

            FileImport fileImport = new FileImport();
            string fileName = fileImport.getFileName();
            string jsonstring = File.ReadAllText(fileName).ToString();
            JObject jsondata = JObject.Parse(jsonstring);

            Tour importTour = new Tour();
            importTour.Name = jsondata["Name"].ToString();
            importTour.Start = jsondata["Start"].ToString();
            importTour.Destination = jsondata["Destination"].ToString();
            importTour.Description = jsondata["Description"].ToString();

            string response = httpCon.GetJsonResponse(importTour.Start, importTour.Destination);
            httpResp.SetJObject(response);
            string imagepath = imageHandler.SaveImage(httpResp.GetMapData(), importTour.Name);
            importTour.Distance = float.Parse(httpResp.GetMapData().Distance);

            try
            {
                db.AddTour(importTour.Name, importTour.Description, importTour.Distance, importTour.Start, importTour.Destination, imagepath);
                MessageBox.Show("Success!");
            }
            catch (Exception)
            {
                log.Error("Importing Tour failed");
            }
        }
    }
}
