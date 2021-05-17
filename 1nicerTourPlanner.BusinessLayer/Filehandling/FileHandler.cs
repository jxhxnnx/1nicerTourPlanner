using _1nicerTourPlanner.Models;
using System.Configuration;
using System.IO;

namespace _1nicerTourPlanner.BusinessLayer.Filehandling
{
    public class FileHandler
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Context context = new Context();
        private string fileName;
        private Tour CurrentTour;
        private string folderPath;
        public FileHandler(Tour tour)
        {
            CurrentTour = tour;
            folderPath = ConfigurationManager.AppSettings["UploadsFolderPath"].ToString() + "\\" + CurrentTour.TourID;
        }

        public void UploadFile()
        {
            CreateDirection();
            fileName = GetFileName();
            context.DownLoadFile(fileName, folderPath + "\\" + Path.GetFileName(fileName));
        }
        public void CreateDirection()
        {
            context.CreateDirection(CurrentTour);
        }
        public string GetFileName()
        {
            return context.GetFileFromDirectory();
        }

    }
}
