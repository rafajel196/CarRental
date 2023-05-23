using CarRental.Application.DTOs;
using MediatR;

namespace CarRental.Application.Functions.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
