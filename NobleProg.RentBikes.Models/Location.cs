using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobleProg.RentBikes.Models
{
    public class Location : Base
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Location(double latitude, double longitude) : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public Location()
        {            
        }
    }
}
