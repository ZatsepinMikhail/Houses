using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Houses_NET_Framework_NotEmpty
{
    public class Coordinate
    {
        public Coordinate(double lat_, double lng_)
        {
            lat = lat_;
            lng = lng_;
        }
        public double lat { get; set; }
        public double lng { get; set; }
    }
}
