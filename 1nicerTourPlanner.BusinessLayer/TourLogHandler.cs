using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1nicerTourPlanner.BusinessLayer
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
