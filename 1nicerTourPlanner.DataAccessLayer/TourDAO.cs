using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1nicerTourPlanner.DataAccessLayer
{
    public class TourDAO
    {
        private IDataAccess dataAccess;
        public TourDAO()
        {
            //check which datasource to use
            dataAccess = new DB();
        }
        public List<Tour> GetTours()
        {
            return dataAccess.GetTours();
        }
    }
}
