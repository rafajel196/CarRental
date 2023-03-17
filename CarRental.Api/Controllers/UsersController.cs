using CarRental.Application.Functions.Users.Queries.GetAllUsers;
using CarRental.Application.Functions.Users.Queries.GetUserModelsCommon;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            var cars = await _mediator.Send(new GetAllUsersQuery());

            return Ok(cars);
        }
    }
}
