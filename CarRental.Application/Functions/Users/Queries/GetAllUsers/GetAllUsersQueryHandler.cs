using AutoMapper;
using CarRental.Application.Contracts.Persistance;
using CarRental.Application.Exceptions;
using CarRental.Application.Functions.Users.Queries.GetUserModelsCommon;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            if (users is null)
            {
                throw new UserNotFoundException();
            }

            var usersDto = _mapper.Map<List<UserDto>>(users);
            return usersDto;
        }
    }
}
