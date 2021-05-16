using _1nicerTourPlanner.DataAccessLayer;
using _1nicerTourPlanner.Models;
using System.Collections.Generic;

namespace _1nicerTourPlanner.BusinessLayer.TourHandling
{
    public class TourHandler
    {
        private TourDAO tourDAO;
        public TourHandler()
        {
            tourDAO = new TourDAO();
        }
        public List<Tour> GetTours()
        {
            return tourDAO.GetTours();
        }
        public List<TourLog> GetLogs(int tourID)
        {
            return tourDAO.GetLogs(tourID);
        }

        public IEnumerable<Tour> Search(string tourName, bool caseSensitive = false)
        {
            return tourDAO.Search(tourName);
        }
        public void DeleteTour(Tour currentTour)
        {
            tourDAO.DeleteTour(currentTour);
        }
        public void CopyTour(Tour currentTour)
        {
            tourDAO.CopyTour(currentTour);
        }
    }
}
