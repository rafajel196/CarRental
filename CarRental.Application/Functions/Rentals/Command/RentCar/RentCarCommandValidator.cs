using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Rentals.Command.RentCar
{
    public class RentCarCommandValidator : AbstractValidator<RentCarCommand>
    {
        public RentCarCommandValidator()
        {
            RuleFor(x => x.CarId)
                .NotEmpty()
                .WithMessage("Car Id must not be empty");
            RuleFor(x => x.RentDate)
                .NotEmpty()
                .WithMessage("Rent date must not be empty")
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("Rent date must be later than now");
            RuleFor(x => x.ReturnDate)
                .NotEmpty()
                .WithMessage("Return date must not be empty")
                .GreaterThan(x => x.RentDate.Date)
                .WithMessage("Return date must be later than rent date");
        }
    }
}
