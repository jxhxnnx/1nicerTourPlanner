using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.Models;
using System.Collections.Generic;

namespace _1nicerTourPlanner.BusinessLayer.LogHandling
{
    public class TourLogHandler
    {
        private TourDAO tourDAO;
        public TourLogHandler()
        {
            tourDAO = new TourDAO();
        }

        public IEnumerable<TourLog> Search(string logName, int tourID, bool caseSensitive = false)
        {
            return tourDAO.SearchLog(logName, tourID);
        }
        public void DeleteSingleLog(TourLog currentLog)
        {
            tourDAO.DeleteSingleLog(currentLog);
        }
    }
}
