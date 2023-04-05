using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Exceptions;
using CarRental.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarRental.Application.Functions.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UpdateUserCommandHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            user.FullName = request.FullName;
            user.Email = request.Email;
            user.BirthDate = request.BirthDate;
            user.LicenceDate = request.LicenceDate;
            user.RoleId = request.RoleId;

            var hashedPassword = _passwordHasher.HashPassword(user, request.Password);
            user.PasswordHash = hashedPassword;

            await _userRepository.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
