using _1nicerTourPlanner.BusinessLayer.MapImageHandling;
using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace _1nicerTourPlanner.BusinessLayer.ExpImpHandling
{
    public class ImportHandler
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private HTTPConnection httpCon;
        private HTTPResponse httpResp;
        private ImageHandler imageHandler;
        private TourDAO tourDAO;
        private JSONImport fileImport;
        private Tour importTour;
        public TourLog tourlog;
        private string fileName;
        private string jsonstring;
        private string response;
        private string imagepath;
        public List<TourLog> logList;

        public ImportHandler()
        {
            httpCon = new HTTPConnection();
            httpResp = new HTTPResponse();
            imageHandler = new ImageHandler();
            fileImport = new JSONImport();
            importTour = new Tour();
            tourDAO = new TourDAO();
        }
        public void ImportTour()
        {
            setImportTour();
            if (fileName != "")
            {
                try
                {
                    if (tourDAO.NameExists(importTour.Name))
                    {
                        MessageBox.Show("Name already exists! Name must be unique");
                        log.Error("Importing Tour failed - Name already exists!");
                    }
                    else
                    {
                        tourDAO.AddTour(importTour.Name, importTour.Description, importTour.Distance, importTour.Start, importTour.Destination, imagepath);
                        AddTourLogs(tourDAO.GetIDtoName(importTour.Name));

                    }

                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }
            }

        }

        public void setImportTour()
        {
            try
            {
                fileName = fileImport.getFileName();
                if (fileName != "")
                {
                    jsonstring = File.ReadAllText(fileName).ToString();
                    JObject jsondata = JObject.Parse(jsonstring);

                    importTour.Name = jsondata["Name"].ToString();
                    importTour.Start = jsondata["Start"].ToString();
                    importTour.Destination = jsondata["Destination"].ToString();
                    importTour.Description = jsondata["Description"].ToString();
                    string logData = jsondata["Logs"].ToString();
                    createLog(logData);
                    response = httpCon.GetJsonResponse(importTour.Start, importTour.Destination);
                    httpResp.SetJObject(response);
                    imagepath = imageHandler.GetImagePath(httpResp.GetMapData(), importTour.Name);
                    importTour.Distance = float.Parse(httpResp.GetMapData().Distance);



                }
                else
                {
                    log.Info("No File chosen");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }
        public JArray SetJsonLogs(string jsonstring)
        {
            JArray logJson = JArray.Parse(jsonstring);
            return logJson;
        }
        public void createLog(string logData)
        {
            logList = new List<TourLog>();
            try
            {
                if (logData != "[]")
                {
                    JArray logJson = SetJsonLogs(logData);
                    foreach (JObject singleProp in logJson)
                    {
                        tourlog = new TourLog();
                        tourlog.Date = DateTime.Parse(singleProp["Date"].ToString());
                        tourlog.Distance = float.Parse(singleProp["Distance"].ToString());
                        tourlog.TotalTime = float.Parse(singleProp["TotalTime"].ToString());
                        tourlog.Name = singleProp["Name"].ToString();
                        tourlog.Report = singleProp["Report"].ToString();
                        tourlog.Rating = int.Parse(singleProp["Rating"].ToString());
                        tourlog.Alone = bool.Parse(singleProp["Alone"].ToString());
                        tourlog.Vehicle = singleProp["Vehicle"].ToString();
                        tourlog.Weather = singleProp["Weather"].ToString();
                        tourlog.Traveller = singleProp["Traveller"].ToString();
                        tourlog.Speed = float.Parse(singleProp["Speed"].ToString());
                        logList.Add(tourlog);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }
        public void AddTourLogs(int tourID)
        {
            if (logList != null && logList.Count > 0)
            {
                foreach (var item in logList)
                {
                    tourDAO.AddLog(item.Date, item.Distance, item.TotalTime, tourID, item.Name, item.Report, item.Rating, item.Alone, item.Vehicle, item.Weather, item.Traveller, item.Speed);
                    MessageBox.Show("Success!");
                    log.Info("Import Tour");
                }
            }
        }
    }
}
