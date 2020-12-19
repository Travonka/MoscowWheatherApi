using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class WeatherData
    {
        public Airport ICAO { get; set; }
        public Date date { get; set; }
        public Wind wind { get; set; }
        public Visability visability { get; set; }
        public Temperature temperature { get; set; }
        public AtmosphericPressure atmosphericPressure { get; set; }
        public WheaterConditions wheaterConditions { get; set; }

    }
}
