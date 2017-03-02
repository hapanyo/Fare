using System;


namespace Fare.Models
{
    public class Ride
    {
        public int Miles { get; set; }
        public int Minutes { get; set; }
        public DateTime StartDateTime { get; set; }
        public States State { get; set; }
    }

    public enum States
    {
        NewYork,
        Other
    }

}