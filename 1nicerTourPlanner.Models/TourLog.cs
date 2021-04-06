using System;

namespace _1nicerTourPlanner.Models
{
    public class TourLog
    {
        public string Name { get; set; }
        public float Distance  { get; set; }
        public DateTime Date { get; set; }
        public string Report { get; set; }
        public int Rating { get; set; }
        public float TotalTime { get; set; }
        public int TourID { get; set; } 
    }
}
