using CarRental.Application.Contracts.Persistance;
using FluentValidation;

namespace CarRental.Application.Functions.CarAddresses.Commands.AddCarAddress
{
    public class AddCarAddressCommandValidator : AbstractValidator<AddCarAddressCommand>
    {
        private readonly ICarAddressRepository _carAddressRepository;

        public AddCarAddressCommandValidator(ICarAddressRepository carAddressRepository)
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

        private bool IsAddressNotExist(AddCarAddressCommand addCarAddressCommand)
        {
            var result = _carAddressRepository.IsAddressExist(addCarAddressCommand.City, addCarAddressCommand.Street);

            return !result;
        }
    }
}
