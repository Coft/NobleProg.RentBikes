using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobleProg.RentBikes.Models
{
    public class Rental : Base
    {
        public int RentalId { get; set; }
        public Bike Bike { get; set; }
        public Station Station { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime? RentalStopDate { get; set; }
        public Person Rentee { get; set; }        
    }
}
