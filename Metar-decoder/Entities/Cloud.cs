using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Cloud
    {
        public CloudCoverege coverege { get; set; } = CloudCoverege.undefined;
        public int lowerBoundaryAltitude { get; set; }
        public int verticalVisability { get; set; }
    }
}
