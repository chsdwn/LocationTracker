using System;

namespace LocationTracker
{
    public class Location
    {
        public Guid? Id { get; set; }
        public String Phone { get; set; }
        public String Longitude { get; set; }
        public String Latitude { get; set; }
        public DateTime Date { get; set; }
    }
}