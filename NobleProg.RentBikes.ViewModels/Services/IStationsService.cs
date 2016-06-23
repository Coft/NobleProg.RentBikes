using NobleProg.RentBikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobleProg.RentBikes.ViewModels.Services
{
    public interface IStationsService
    {
        ICollection<Station> GetStations();
    }
}
