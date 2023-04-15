using CarRental.Common.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Exceptions
{
    public class CannotRentThePremiumCarException : BadRequestException
    {
        public CannotRentThePremiumCarException() : base("Cannot rent the premium cars with a driving licence less than 3 years old")
        {
        }
    }
}
