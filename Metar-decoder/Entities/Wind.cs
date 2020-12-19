using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Wind
    {
        public int direction { get; set; } 
        public int speed { get; set; } 
        public int gustsSpeed { get; set; } 
        public bool gusts { get; set; } 
        public bool variable { get; set; }
        public Measurmnet measurmnet { get; set; } 
        public int from { get; set; }
        public int to { get; set; } 
        public bool changes { get; set; }
    }
}
