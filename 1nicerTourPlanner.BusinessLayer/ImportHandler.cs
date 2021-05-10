using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1nicerTourPlanner.BusinessLayer
{
    public class ImportHandler
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private HTTPConnection httpCon;
        private HTTPResponse httpResp;
        private ImageHandler imageHandler;
        private DB db = new DB();
        private FileImport fileImport;
        private Tour importTour;
        private string fileName;
        private string jsonstring;
        private string response;
        private string imagepath;

        public ImportHandler()
        {
            httpCon = new HTTPConnection();
            httpResp = new HTTPResponse();
            imageHandler = new ImageHandler();
            fileImport = new FileImport();
            importTour = new Tour();
        }
        public void ImportTour()
        {
            fileName = fileImport.getFileName();
            jsonstring = File.ReadAllText(fileName).ToString();
            JObject jsondata = JObject.Parse(jsonstring);
           
            importTour.Name = jsondata["Name"].ToString();
            importTour.Start = jsondata["Start"].ToString();
            importTour.Destination = jsondata["Destination"].ToString();
            importTour.Description = jsondata["Description"].ToString();

            response = httpCon.GetJsonResponse(importTour.Start, importTour.Destination);
            httpResp.SetJObject(response);
            imagepath = imageHandler.SaveImage(httpResp.GetMapData(), importTour.Name);
            importTour.Distance = float.Parse(httpResp.GetMapData().Distance);

            try
            {
                if (db.NameExists(importTour.Name))
                {
                    MessageBox.Show("Name already exists! Name must be unique");
                    log.Error("Importing Tour failed - name already exists");
                }
                else
                {
                    db.AddTour(importTour.Name, importTour.Description, importTour.Distance, importTour.Start, importTour.Destination, imagepath);
                    MessageBox.Show("Success!");
                    
                    log.Info("Import Tour");
                }

            }
            catch (Exception)
            {
                log.Error("Importing Tour failed");
            }
        }

    }
}
