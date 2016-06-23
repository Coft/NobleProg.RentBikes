using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NobleProg.RentBikes.Models;
using System.Threading;

namespace NobleProg.RentBikes.ViewModels.Services
{
    public class MockStationsService : IStationsService
    {
        public ICollection<Station> GetStations()
        {
            var stations = new List<Station>()
            {
                new Station
                {
                    StationId = 1,
                    StationNumber = "S01",
                    StationName = "WaWa Centrum",
                    StationLocation = new Location(52.244573710696, 20.9999907016754)
                },
                new Station
                {
                    StationId = 2,
                    StationNumber = "S02",
                    StationName = "WaWa Wola",
                    StationLocation = new Location( 52.2760716067128, 20.9617102146149) ,
                    IsActive = false,
                },
                new Station
                {
                    StationId = 3,
                    StationNumber = "S03",
                    StationName = "WaWa Lotnisko",
                    StationLocation =  new Location(52.2645854944588, 20.9312510490417)
                },
                new Station
                {
                    StationId = 4,
                    StationNumber = "S04",
                    StationName = "WaWa dkjdks",
                    StationLocation = new Location(52.2545854944588, 20.9212510490417)
                },
                
            };

            return stations;
        }
    }
}
