using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Exceptions;
using MediatR;

namespace CarRental.Application.Functions.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            await _userRepository.DeleteAsync(user);

            return Unit.Value;
        }
    }
}
