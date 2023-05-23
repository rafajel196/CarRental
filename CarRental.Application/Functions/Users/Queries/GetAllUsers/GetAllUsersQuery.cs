using CarRental.Application.DTOs;
using MediatR;

namespace CarRental.Application.Functions.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserDto>>
    {
    }
}
