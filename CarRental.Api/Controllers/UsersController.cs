using CarRental.Application.Functions.Users.Queries.GetAllUsers;
using CarRental.Application.Functions.Users.Queries.GetUserById;
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
            var users = await _mediator.Send(new GetAllUsersQuery());

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById([FromRoute] int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery() { Id = id });

            return Ok(user);
        }
    }
}
