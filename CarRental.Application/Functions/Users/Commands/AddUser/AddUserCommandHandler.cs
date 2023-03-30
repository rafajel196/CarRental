using CarRental.Application.Contracts.Persistance;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Users.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                FullName = request.FullName,
                Email = request.Email,
                BirthDate = request.BirthDate,
                LicenceDate = request.LicenceDate
            };

            var addUser = await _userRepository.AddAsync(user);

            return addUser.Id;
        }
    }
}
