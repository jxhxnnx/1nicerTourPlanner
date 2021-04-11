using _1nicerTourPlanner.Models; 
using System.Collections.Generic;

namespace _1nicerTourPlanner.BusinessLayer
{
    public interface ITourFactory
    {
        IEnumerable<Tour> GetTours();
        IEnumerable<Tour> Search(string tourName, bool caseSensitive = false);
        public void changeRefreshFlag();
        public bool Refresh_flag { get; }
    }
}
