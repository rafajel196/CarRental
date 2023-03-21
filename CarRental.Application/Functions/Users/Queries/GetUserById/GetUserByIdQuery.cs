using CarRental.Application.Functions.Cars.Queries.GetCarDto;
using CarRental.Application.Functions.Users.Queries.GetUserModelsCommon;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
