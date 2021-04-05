using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1nicerTourPlanner.DataAccessLayer
{
    public class TourLogDAO
    {
        private IDataAccess dataAccess;
        public TourLogDAO()
        {
            //check which datasource to use
            dataAccess = new DB();
        }
        public List<TourLog> GetLogs()
        {
            return dataAccess.GetLogs();
        }
    }
}
