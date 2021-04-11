using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
