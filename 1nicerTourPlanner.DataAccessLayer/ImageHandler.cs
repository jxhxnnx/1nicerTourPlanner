using _1nicerTourPlanner.Models;
using System;
using System.Configuration;
using System.Net;

namespace _1nicerTourPlanner.DataAccessLayer
{
    public class ImageHandler
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string folderPath;
        private string imageUrl;


        public ImageHandler()
        {
            folderPath = ConfigurationManager.AppSettings["FolderPath"].ToString();
            //folderPath = "C:\\Users\\Lenovo\\Desktop\\FHTechnikum\\4.Semester\\SWE2\\1nicerTourPlanner\\1nicerTourPlanner\\Images";
            imageUrl = ConfigurationManager.AppSettings["ImageUrl"].ToString();
            //imageUrl = "http://www.mapquestapi.com/staticmap/v5/map?key=cAPnl8Ur8VmsYmXA4igAOLIb6qVOKS6Q&amp;size=640,480&amp;defaultMarker=none&amp;zoom=11&amp;rand=73&amp;7758036&amp;"; 
            System.IO.Directory.CreateDirectory(folderPath);
        }

        public string GetImagePath(MapInfos mapInfo, string tourname)
        {
            string imagePath = folderPath + "\\" + tourname + ".png";
            string finalUrl = imageUrl + "session=" + mapInfo.sessionId +
                "&boundingBox=" + mapInfo.boundingBox[0].ToString() + "," +
                                    mapInfo.boundingBox[1].ToString() + "," +
                                    mapInfo.boundingBox[2].ToString() + "," +
                                    mapInfo.boundingBox[3].ToString();

            downLoadFile(finalUrl, imagePath);
            return imagePath;
        }

        public void downLoadFile(string finalUrl, string imagePath)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(finalUrl, imagePath);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }
    }
}
