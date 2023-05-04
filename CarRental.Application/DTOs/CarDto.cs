using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.DTOs
{
    public record CarDto
    {
        public string Mark { get; set; }
        public string Model { get; set; }
    }
}
