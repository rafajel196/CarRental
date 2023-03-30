using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Functions.CarAddresses.Commands.AddCarAddress;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarAddresses.Commands.UpdateCarAddress
{
    public class UpdateCarAddressCommandValidator : AbstractValidator<UpdateCarAddressCommand>
    {
        private ICarAddressRepository _carAddressRepository;

        public UpdateCarAddressCommandValidator(ICarAddressRepository carAddressRepository)
        {
            _carAddressRepository = carAddressRepository;

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("City must not be empty")
                .MaximumLength(20)
                .WithMessage("City is too length");
            RuleFor(x => x.Street)
                .NotEmpty()
                .WithMessage("Street must not be empty")
                .MaximumLength(30)
                .WithMessage("Street is too length");

            RuleFor(x => x)
                .Must(IsAddressNotExist)
                .WithMessage("Car address already exist");
        }

        private bool IsAddressNotExist(UpdateCarAddressCommand updateCarAddressCommand)
        {
            var result = _carAddressRepository.IsAddressExist(updateCarAddressCommand.City, updateCarAddressCommand.Street);

            return !result;
        }
    }
}
