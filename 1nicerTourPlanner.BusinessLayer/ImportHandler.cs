using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace _1nicerTourPlanner.BusinessLayer
{
    public class ImportHandler
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private HTTPConnection httpCon;
        private HTTPResponse httpResp;
        private ImageHandler imageHandler;
        private TourDAO tourDAO;
        private FileImport fileImport;
        private Tour importTour;
        private TourLog tourlog;
        private string fileName;
        private string jsonstring;
        private string response;
        private string imagepath;
        List<TourLog> logList;

        public ImportHandler()
        {
            httpCon = new HTTPConnection();
            httpResp = new HTTPResponse();
            imageHandler = new ImageHandler();
            fileImport = new FileImport();
            importTour = new Tour();
            tourDAO = new TourDAO();
        }
        public void ImportTour()
        {
            setImportTour();
            try
            {
                if (tourDAO.NameExists(importTour.Name))
                {
                    MessageBox.Show("Name already exists! Name must be unique");
                    log.Error("Importing Tour failed - name already exists");
                }
                else
                {
                    tourDAO.AddTour(importTour.Name, importTour.Description, importTour.Distance, importTour.Start, importTour.Destination, imagepath);
                    AddTourLogs(tourDAO.GetIDtoName(importTour.Name));
                    MessageBox.Show("Success!");

                    log.Info("Import Tour");
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public void setImportTour()
        {
           try
            {
                fileName = fileImport.getFileName();
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
        public void AddTourLogs(int tourID)
        {
            foreach(var item in logList)
            {
                tourDAO.AddLog(item.Date, item.Distance, item.TotalTime, tourID, item.Name, item.Report, item.Rating, item.Alone, item.Vehicle, item.Weather, item.Traveller, item.Speed);
            }
        }
    }
}
