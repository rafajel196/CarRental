using CarRental.Application.Contracts.Persistance;
using CarRental.Application.DTOs;
using CarRental.Application.Exceptions;
using MediatR;

namespace CarRental.Application.Functions.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            if (users is null)
            {
                throw new UserNotFoundException();
            }

            var usersDto = new List<UserDto>();
            foreach (var user in users)
            {
                usersDto.Add(new UserDto()
                {
                    FullName = user.FullName,
                    Email = user.Email
                });
            }

            return usersDto;
        }
    }
}
