using FluentValidation.Attributes;
using NobleProg.RentBikes.Models.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobleProg.RentBikes.Models
{
    [Validator(typeof(StationValidator))]
    public class Station : Base
    {
        private string _stationName;

        public string StationName
        {
            get { return _stationName; }
            set
            {
                _stationName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }


        public int StationId { get; set; }
        public string StationNumber { get; set; }
        //public string StationName { get; set; }
        public Location StationLocation { get; set; }
        //public string FullName { get { return String.Format("({0}) - {1}", StationNumber, StationName); } }
        //public string FullName { get { return $"({StationNumber}) - {StationName}"; } }
        public string FullName => $"({StationNumber}) - {StationName}";
        public bool IsActive { get; set; } = true;

        public override string ToString()
        {
            return this.FullName;
        }

    }
}
