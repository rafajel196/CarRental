﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.DTOs
{
    public record CarAddressDto
    {
        public string City { get; set; }
        public string Street { get; set; }
    }
}
