using CarRental.Application.Contracts.Persistance;
using CarRental.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                FullName = request.FullName,
                Email = request.Email,
                BirthDate = request.BirthDate,
                LicenceDate = request.LicenceDate,
                RoleId = request.RoleId
            };
            var hashedPassword = _passwordHasher.HashPassword(user, request.Password);
            user.PasswordHash = hashedPassword;

            await _userRepository.AddAsync(user);

            return Unit.Value;
        }
    }
}
