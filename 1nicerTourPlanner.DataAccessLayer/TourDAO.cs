using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _1nicerTourPlanner.DataAccessLayer
{
    public class TourDAO
    {
        private IDataAccess dataAccess;
        public TourDAO()
        {
            dataAccess = new DB();
        }
        public List<Tour> GetTours()
        {
            return dataAccess.GetTours();
        }
        public List<TourLog> GetLogs(int tourID)
        {
            return dataAccess.GetLogs(tourID);
        }

        

        public void ModifyTour(int tourID, string name, string description, float distance)
        {
            dataAccess.ModifyTour(tourID, name, description, distance);
        }
        public void AddTour(string name, string description, float distance, string start, string destination, string imagepath)
        {
            dataAccess.AddTour(name, description, distance, start, destination, imagepath);
        }
        public void DeleteTour(Tour currentTour)
        {
            dataAccess.DeleteTour(currentTour);
        }
        public void DeleteLogs(int tourID)
        {
            dataAccess.DeleteLogs(tourID);
        }
        public void CopyTour(Tour currentTour)
        {
            dataAccess.CopyTour(currentTour);
        }
        public void AddLog(DateTime date, float distance, float totTime, int tourID, string name, string report, int rating, bool alone, string vehicle, string weather, string traveller, float speed)
        {
            dataAccess.AddLog(date, distance, totTime, tourID, name, report, rating, alone, vehicle, weather, traveller, speed);
        }
        public bool NameExists(string name)
        {
            return dataAccess.NameExists(name);
        }
        public IEnumerable<Tour> Search(string tourName, bool caseSensitive = false)
        {
            IEnumerable<Tour> tour = GetTours();
            if (caseSensitive)
            {
                return tour.Where(x => x.Name.Contains(tourName));
            }
            return tour.Where(x => x.Name.ToLower().Contains(tourName.ToLower()));
        }

        public IEnumerable<TourLog> SearchLog(string logName, int tourID, bool caseSensitive = false)
        {
            IEnumerable<TourLog> tour = GetLogs(tourID);
            if (caseSensitive)
            {
                return tour.Where(x => x.Name.Contains(logName));
            }
            return tour.Where(x => x.Name.ToLower().Contains(logName.ToLower()));
        }

        public void DeleteSingleLog(TourLog log)
        {
            dataAccess.DeleteSingleLog(log);
        }

        public void ModifyLog(TourLog log)
        {
            dataAccess.ModifyLog(log);
        }

        public int GetIDtoName(string name)
        {
            return dataAccess.GetIDtoName(name);
        }
    }
}
