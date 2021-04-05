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
        public IEnumerable<TourLog> GetLogs()
        {
            return tourLogDAO.GetLogs();
        }

        public IEnumerable<TourLog> Search(string logName, bool caseSensitive = false)
        {
            IEnumerable<TourLog> logs = GetLogs();
            if(caseSensitive)
            {
                logs.Where(x => x.Name.Contains(logName));
            }
            return logs.Where(x => x.Name.ToLower().Contains(logName.ToLower()));
        }
    }
}
