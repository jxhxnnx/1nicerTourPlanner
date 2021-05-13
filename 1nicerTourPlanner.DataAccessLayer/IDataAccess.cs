using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;


namespace _1nicerTourPlanner.DataAccessLayer
{
    public interface IDataAccess
    {
        public List<Tour> GetTours();
        public List<TourLog> GetLogs(int tourID);
        public void ModifyTour(int tourID, string name, string description, float distance);
        public void AddTour(string name, string description, float distance, string start, string destination, string imagepath);
        public void DeleteTour(Tour currentTour);
        public void DeleteLogs(int tourID);
        public void CopyTour(Tour currentTour);
        public void AddLog(DateTime date, float distance, float totTime, int tourID, string name, string report, int rating, bool alone, string vehicle, string weather, string traveller, float speed);
        public bool NameExists(string name);
        public void DeleteSingleLog(TourLog log);
        public void ModifyLog(TourLog log);
        public int GetIDtoName(string name);


    }
}
