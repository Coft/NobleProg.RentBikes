using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobleProg.RentBikes.Models
{
    public class Bike : Base
    {
        public int BikeId { get; set; }
        public string BikeNumber { get; set; }
        public DateTime ProductionDate { get; set; }

    }
}
