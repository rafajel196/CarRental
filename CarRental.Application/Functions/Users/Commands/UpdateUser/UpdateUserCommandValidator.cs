using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("Full name must not be empty")
                .MaximumLength(40)
                .WithMessage("Too long full name");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email must not be empty")
                .EmailAddress()
                .WithMessage("Invalid e-mail address");
            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage("Birth date must not be empty")
                .LessThan(d => DateTime.Now)
                .WithMessage("Invalid date");
            RuleFor(x => x.LicenceDate)
                .NotEmpty()
                .WithMessage("Licence date must not be empty")
                .LessThan(d => DateTime.Now).GreaterThan(d => d.BirthDate)
                .WithMessage("Invalid date");
        }
    }
}
