using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _1nicerTourPlanner.BusinessLayer
{
    internal class TourFactoryImpl : ITourFactory
    {

        private TourDAO tourDAO = new TourDAO();
        public IEnumerable<Tour> GetTours()
        {
            return tourDAO.GetTours();
        }

        public IEnumerable<Tour> Search(string tourName, bool caseSensitive = false)
        {
            IEnumerable<Tour> tour = GetTours();
            if(caseSensitive)
            {
               return tour.Where(x => x.Name.Contains(tourName));
            }
            return tour.Where(x => x.Name.ToLower().Contains(tourName.ToLower()));
        }
    }
}
