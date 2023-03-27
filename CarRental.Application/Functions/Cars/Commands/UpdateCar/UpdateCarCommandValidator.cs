using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Commands.UpdateCar
{
    public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
    {
        public UpdateCarCommandValidator()
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
                .WithMessage("Fuel consumption must not be empty");
            RuleFor(x => x.CarAddressId)
                .NotEmpty()
                .WithMessage("Car address Id must not be empty");
        }
    }
}
