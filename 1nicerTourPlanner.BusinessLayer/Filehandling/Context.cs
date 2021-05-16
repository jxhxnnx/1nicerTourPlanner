using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _1nicerTourPlanner.BusinessLayer.Filehandling
{
    public class Context
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IFileHandler handler;
        public Context()
        {

        }
        public Context(IFileHandler _handler)
        {
            handler = _handler;
        }

        public void SetHandler(IFileHandler _handler)
        {
            handler = _handler;
        }

        public string GetFileFromDirectory()
        {
            string filename = "";
            try
            {
                Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
                dialog.FileName = "File";
                dialog.DefaultExt = ".png";
                dialog.Filter = "PNG files (.png)|*.png|" +
                                "PDF files (.pdf)|*.pdf|" +
                                "TXT files (.txt)|*.txt";
                Nullable<bool> result = dialog.ShowDialog();
                if (result == true)
                {

                    filename = dialog.FileName;
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return filename;


        }
        public void CreateDirection(Tour CurrentTour)
        {
            try
            {
                string filesFolder = ConfigurationManager.AppSettings["UploadsFolderPath"].ToString();
                string folderPath = filesFolder + "\\" + CurrentTour.TourID.ToString();
                Directory.CreateDirectory(folderPath);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public void DownLoadFile(string finalUrl, string imagePath)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(finalUrl, imagePath);
                }
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
            }


        }
    }
}
