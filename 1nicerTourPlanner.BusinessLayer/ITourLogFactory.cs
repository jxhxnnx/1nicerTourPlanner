using _1nicerTourPlanner.Models;
using System.Collections.Generic;

namespace _1nicerTourPlanner.BusinessLayer
{
    public interface ITourLogFactory
    {
        IEnumerable<TourLog> GetLogs(int tourID);
        IEnumerable<TourLog> Search(string logName, int tourID, bool caseSensitive = false);
    }
}
