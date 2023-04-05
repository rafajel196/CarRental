using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Exceptions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Users.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        private IUserRepository _userRepository;

        public RegisterUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

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
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(8)
                .WithMessage("Minimum length is 8 characters")
                .Equal(x => x.ConfirmPassword)
                .WithMessage("Passwords are not equal");
            RuleFor(x => x.RoleId)
                .NotEmpty()
                .WithMessage("Role Id must not be empty")
                .GreaterThan(0)
                .LessThan(4);

            RuleFor(x => x)
                .Must(IsEmailAlreadyInUse)
                .WithMessage("Email already in use");
        }

        private bool IsEmailAlreadyInUse(RegisterUserCommand command)
        {
            var isEmailAlreadyInUse = _userRepository.IsEmailExist(command.Email);

            return !isEmailAlreadyInUse;
        }
    }
}
