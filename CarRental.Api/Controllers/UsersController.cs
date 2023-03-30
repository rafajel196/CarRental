using CarRental.Application.Functions.Users.Commands.AddUser;
using CarRental.Application.Functions.Users.Commands.DeleteUser;
using CarRental.Application.Functions.Users.Commands.UpdateUser;
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

        [HttpPost]
        public async Task<ActionResult<int>> AddUser([FromBody] AddUserCommand addUserCommand)
        {
            var user = await _mediator.Send(addUserCommand);

            return Created($"Created user id = {user}", null);
        }

        [HttpPut]
        public async Task<ActionResult<Unit>> UpdateUser([FromBody] UpdateUserCommand updateUserCommand)
        {
            var user = await _mediator.Send(updateUserCommand);

            return Ok("User updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteUser([FromRoute] int id)
        {
            var user = await _mediator.Send(new DeleteUserCommand() { Id = id });

            return Ok("User deleted");
        }
    }
}
