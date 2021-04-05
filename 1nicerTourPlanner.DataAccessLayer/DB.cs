using _1nicerTourPlanner.Models;
using System;
using System.Collections.Generic;

namespace _1nicerTourPlanner.DataAccessLayer
{
    public class DB : IDataAccess
    {
        private string connectionString;
        public DB()
        {
            //get connection data e.g. from config file
            connectionString = "...";
            //establish connection with db
        }
        public List<TourLog> GetLogs()
        {
            //select SQL query
            return new List<TourLog>()
            {
                new TourLog(){Name = "Log1"},
                new TourLog(){Name = "Log2"},
                new TourLog(){Name = "Log3"},
                new TourLog(){Name = "Log4"},
                new TourLog(){Name = "Log5"}
            };
        }

        public List<Tour> GetTours()
        {
            return new List<Tour>()
            {
                new Tour(){Name = "Billa"},
                new Tour(){Name = "Schwimmbad"},
                new Tour(){Name = "Merkur"},
                new Tour(){Name = "Tankstelle"},
                new Tour(){Name = "Tichy"}
            };
        }
    }
}
