using System;

namespace _1nicerTourPlanner.Models
{
    public class TourLog
    {
        public string Name { get; set; }
        public float Distance { get; set; }
        public DateTime Date { get; set; }
        public string Report { get; set; }
        public int Rating { get; set; }
        public float TotalTime { get; set; }
        public int TourID { get; set; }
        public bool Alone { get; set; }
        public string Vehicle { get; set; }
        public string Weather { get; set; }
        public string Traveller { get; set; }
        public float Speed { get; set; }
        public int logID { get; set; }
    }
}
