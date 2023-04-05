using CarRental.Application.Functions.Rentals.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [ApiController]
    [Route("api/rental")]
    [Authorize]
    public class RentalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<string>> RentCar([FromBody] RentCarCommand rentCarCommand)
        {
            var rentedCar = await _mediator.Send(rentCarCommand);

            return Ok(rentedCar);
        }
    }
}
