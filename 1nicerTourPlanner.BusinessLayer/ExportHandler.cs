using _1nicerTourPlanner.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1nicerTourPlanner.BusinessLayer
{
    public class ExportHandler
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string JSONresult;
        private string folderPath;
        private string exportPath;


        public void ExportTour(Tour CurrentTour)
        {
            JSONresult = JsonConvert.SerializeObject(CurrentTour);
            folderPath = ConfigurationManager.AppSettings["ExportFolderPath"].ToString();
            exportPath = folderPath + "\\" + CurrentTour.Name + ".json";
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
                log.Info("Export Tour");
            }
            catch (Exception)
            {
                log.Error("Exporting Tour failed");
            }
        }
    }
}
