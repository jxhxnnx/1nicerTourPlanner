using System;
using System.Collections.Generic;

namespace _1nicerTourPlanner.Models
{
    public class Tour
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public  float Distance  { get; set; }
        public int TourID { get; set; }
        public List<TourLog> Logs;
    }
}
