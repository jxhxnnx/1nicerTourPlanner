using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _1nicerTourPlanner.DataAccessLayer
{
    public class ImageHandler
    {
        private string folderPath;
        private string imageUrl;


        public ImageHandler()
        {
            folderPath = ConfigurationManager.AppSettings["FolderPath"].ToString();
            imageUrl = ConfigurationManager.AppSettings["ImageUrl"].ToString();
            System.IO.Directory.CreateDirectory(folderPath);
        }

        public string SaveImage(MapInfos mapInfo, string tourname)
        {
            string imagePath = folderPath + "\\" + tourname + ".png";
            string finalUrl = imageUrl + "session=" + mapInfo.sessionId +
                "&boundingBox=" + mapInfo.boundingBox[0].ToString() + "," +
                                    mapInfo.boundingBox[1].ToString() + "," +
                                    mapInfo.boundingBox[2].ToString() + "," +
                                    mapInfo.boundingBox[3].ToString();
            
            using(WebClient client = new WebClient())
            {
                client.DownloadFile(finalUrl, imagePath);
            }
            return imagePath;
        }
    }
}
