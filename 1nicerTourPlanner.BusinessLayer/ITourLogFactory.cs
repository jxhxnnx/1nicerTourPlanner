using _1nicerTourPlanner.Models;
using System.Collections.Generic;

namespace _1nicerTourPlanner.BusinessLayer
{
    public interface ITourLogFactory
    {
        IEnumerable<TourLog> GetLogs();
        IEnumerable<TourLog> Search(string logName, bool caseSensitive = false);
    }
}
