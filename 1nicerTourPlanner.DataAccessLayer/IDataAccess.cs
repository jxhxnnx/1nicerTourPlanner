﻿using _1nicerTourPlanner.Models;
using System.Collections.Generic;


namespace _1nicerTourPlanner.DataAccessLayer
{
    interface IDataAccess
    {
        public List<Tour> GetTours();
        public List<TourLog> GetLogs(int tourID);
    }
}
