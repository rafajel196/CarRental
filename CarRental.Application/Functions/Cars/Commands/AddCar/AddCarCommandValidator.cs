﻿using CarRental.Application.Contracts.Persistance;
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
        private readonly ICarAddressRepository _carAddressRepository;
        public AddCarCommandValidator(ICarAddressRepository carAddressRepository)
        {
            _carAddressRepository = carAddressRepository;

            RuleFor(x => x.Mark)
                .NotEmpty()
                .WithMessage("Mark must not be empty")
                .MaximumLength(15)
                .WithMessage("Mark is too long");
            RuleFor(x => x.Model)
                .NotEmpty()
                .WithMessage("Model must not be empty")
                .MaximumLength(40)
                .WithMessage("Model is too long"); ;
            RuleFor(x => x.RegNumber)
                .NotEmpty()
                .WithMessage("Registration number must not be empty")
                .MaximumLength(10)
                .WithMessage("Registration number is too long");
            RuleFor(x => x.FuelConsumption)
                .NotEmpty()
                .WithMessage("Fuel consumption must not be empty")
                .PrecisionScale(3, 1, false)
                .WithMessage("The value of the 'Fuel Consumption' field cannot be longer than 3 digits with 1 digit after the decimal point allowed");
            RuleFor(x => x.CarAddressId)
                .NotEmpty()
                .WithMessage("Car address Id must not be empty");

            RuleFor(x => x)
                .Must(IsCarAddressExist)
                .WithMessage("Car address not exist");
        }

        private bool IsCarAddressExist(AddCarCommand addCarCommand)
        {
            var result = _carAddressRepository.IsCarAddressExist(addCarCommand.CarAddressId);

            return result;
        }
    }
}
