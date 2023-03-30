using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

            await _userRepository.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
