﻿namespace CarRental.Application.Exceptions
{
    public abstract class CarRentalException : Exception
    {
        protected CarRentalException(string message) : base(message) { }
    }

    public abstract class NotFoundException : CarRentalException
    {
        protected NotFoundException(string message) : base(message) { }
    }

    public abstract class BadRequestException : CarRentalException
    {
        protected BadRequestException(string message) : base(message) { }
    }

    public abstract class ValidationErrorException : CarRentalException
    {
        protected ValidationErrorException(string message) : base(message) { }
    }
}
