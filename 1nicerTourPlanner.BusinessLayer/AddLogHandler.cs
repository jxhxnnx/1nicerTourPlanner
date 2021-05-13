using _1nicerTourPlanner.DataAccessLayer;
using System;

namespace _1nicerTourPlanner.BusinessLayer
{
    public class AddLogHandler
    {
        private TourDAO tourDAO;

        public AddLogHandler()
        {
            tourDAO = new TourDAO();
        }
        public void AddLog(DateTime Date, float Distance, float TotTime, int TourID, string Name, string Report, int Rating, bool Alone, string Vehicle, string Weather, string Traveller, float Speed)
        {
            tourDAO.AddLog(Date, Distance, TotTime, TourID, Name, Report, Rating, Alone, Vehicle, Weather, Traveller, Speed);
        }
    }
}
