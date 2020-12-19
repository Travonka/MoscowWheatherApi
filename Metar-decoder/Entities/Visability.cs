using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Visability
    {
        public int prevailingVisibility { get; set; }
        public int minimumVisability { get; set; }
        public Directions direction 
        { get;set; }
        public DistanceMeasurmnet measurmnet { get; set; }
    }
}
