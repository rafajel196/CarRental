using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Commands.AddCar
{
    public class AddCarCommandValidator : AbstractValidator<AddCarCommand>
    {
        public AddCarCommandValidator()
        {
            RuleFor(x => x.Mark)
                .NotEmpty()
                .WithMessage("Mark must not be empty");
            RuleFor(x => x.Model)
                .NotEmpty()
                .WithMessage("Model must not be empty");
            RuleFor(x => x.RegNumber)
                .NotEmpty()
                .WithMessage("Registration number must not be empty");
            RuleFor(x => x.FuelConsumption)
                .NotEmpty()
                .WithMessage("Fuel consumption must not be empty"); //scale precision nie działa, wyrzuca exception something went wrong
            RuleFor(x => x.CarAddressId)
                .NotEmpty()
                .WithMessage("Car address Id must not be empty");
        }
    }
}
