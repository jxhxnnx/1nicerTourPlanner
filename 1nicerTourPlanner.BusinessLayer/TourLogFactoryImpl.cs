using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _1nicerTourPlanner.BusinessLayer
{
    internal class TourLogFactoryImpl : ITourLogFactory
    {
        private TourLogDAO tourLogDAO = new TourLogDAO();
        public IEnumerable<TourLog> GetLogs(int tourID)
        {
            return tourLogDAO.GetLogs(tourID);
        }

        public IEnumerable<TourLog> Search(string logName, int tourID, bool caseSensitive = false)
        {
            IEnumerable<TourLog> logs = GetLogs(tourID);
            if(caseSensitive)
            {
                logs.Where(x => x.Name.Contains(logName));
            }
            return logs.Where(x => x.Name.ToLower().Contains(logName.ToLower()));
        }
    }
}
