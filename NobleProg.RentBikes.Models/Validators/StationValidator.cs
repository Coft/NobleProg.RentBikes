using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobleProg.RentBikes.Models.Validators
{
    public class StationValidator : AbstractValidator<Station>
    {
        public StationValidator()
        {
            RuleFor(p => p.StationName)
                .NotEmpty();

            RuleFor(p => p.StationNumber)
                .Length(1, 5);
        }
    }
}
