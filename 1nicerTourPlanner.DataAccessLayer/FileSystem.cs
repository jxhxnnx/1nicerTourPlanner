using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;

namespace _1nicerTourPlanner.DataAccessLayer
{
    class FileSystem : IDataAccess
    {
        private string filePath;
        public FileSystem()
        {
            //get file path from config file
            filePath = "...";
        }

        public void AddLog(DateTime date, float distance, float totTime, int tourID, string name, string report, int rating, bool alone, string vehicle, string weather, string traveller, float speed)
        {
            throw new NotImplementedException();
        }

        public void AddTour(string name, string description, float distance, string start, string destination, string imagepath)
        {
            throw new NotImplementedException();
        }

        public void CopyTour(Tour currentTour)
        {
            throw new NotImplementedException();
        }

        public void DeleteLogs(int tourID)
        {
            throw new NotImplementedException();
        }

        public void DeleteSingleLog(TourLog log)
        {
            throw new NotImplementedException();
        }

        public void DeleteTour(Tour currentTour)
        {
            throw new NotImplementedException();
        }

        public int GetIDtoName(string name)
        {
            throw new NotImplementedException();
        }

        public List<TourLog> GetLogs(int tourID)
        {
            throw new NotImplementedException();
        }

        public List<Tour> GetTours()
        {
            //get items from file system
            return new List<Tour>()
            {
                new Tour(){Name = "Billa"},
                new Tour(){Name = "Merkur"},
                new Tour(){Name = "Hofer"},
                new Tour(){Name = "Spar"},
                new Tour(){Name = "Jet (Wochenend-Alternative)"}
            };
        }

        public void ModifyLog(TourLog log)
        {
            throw new NotImplementedException();
        }

        public void ModifyTour(int tourID, string name, string description, float distance)
        {
            throw new NotImplementedException();
        }

        public bool NameExists(string name)
        {
            throw new NotImplementedException();
        }
    }
}
