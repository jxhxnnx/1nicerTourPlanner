using _1nicerTourPlanner.Models;
using System.Collections.Generic;


namespace _1nicerTourPlanner.DataAccessLayer
{
    interface IDataAccess
    {
        public List<TourLog> GetLogs();
        public List<Tour> GetTours();
    }
}
