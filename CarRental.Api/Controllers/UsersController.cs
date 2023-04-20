using CarRental.Application.DTOs;
using CarRental.Application.Functions.Users.Commands.DeleteUser;
using CarRental.Application.Functions.Users.Commands.LoginUser;
using CarRental.Application.Functions.Users.Commands.RegisterUser;
using CarRental.Application.Functions.Users.Commands.UpdateUser;
using CarRental.Application.Functions.Users.Queries.GetAllUsers;
using CarRental.Application.Functions.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : CarRentalBaseController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("register")]
        public async Task<ActionResult<Unit>> RegisterUser([FromBody] RegisterUserCommand registerUserCommand)
        {
            var user = await _mediator.Send(registerUserCommand);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginUser([FromBody] LoginUserCommand loginUserCommand)
        {
            var token = await _mediator.Send(loginUserCommand);

            return Ok(token);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());

            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<UserDto>> GetUserById([FromRoute] int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery() { Id = id });

            return Ok(user);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Unit>> UpdateUser([FromBody] UpdateUserCommand updateUserCommand)
        {
            var user = await _mediator.Send(updateUserCommand);

            return Ok("User updated");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<Unit>> DeleteUser([FromRoute] int id)
        {
            var user = await _mediator.Send(new DeleteUserCommand() { Id = id });

            return Ok("User deleted");
        }
    }
}
