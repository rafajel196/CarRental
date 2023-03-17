using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Abstractions.Exceptions
{
    public abstract class CarRentalException : Exception
    {
        protected CarRentalException(string message) : base(message) { }
    }
}
