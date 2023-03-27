﻿using CarRental.Common.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Exceptions
{
    public class CarNotFoundException : NotFoundException
    {
        public CarNotFoundException() : base("Car not found")
        {
        }
    }
}
