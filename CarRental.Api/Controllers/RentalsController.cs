using CarRental.Application.Functions.Rentals.Command.RentCar;
using CarRental.Application.Functions.Rentals.Command.ReturnCar;
using CarRental.Application.Functions.Rentals.Query.Calculator;
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

        [HttpPost("rent")]
        [Authorize(Policy = "AtLeast18")]
        public async Task<ActionResult<string>> RentCar([FromBody] RentCarCommand rentCarCommand)
        {
            var rentedCar = await _mediator.Send(rentCarCommand);

            return Ok(rentedCar);
        }

        [HttpPost("return")]
        public async Task<ActionResult<string>> ReturnCar([FromBody] ReturnCarCommand returnCarCommand)
        {
            var returnedCar = await _mediator.Send(returnCarCommand);

            return Ok(returnedCar);
        }

        [HttpGet("calculate")]
        public async Task<ActionResult<CalculateCostQueryResponse>> CalculateCost([FromBody] CalculateCostQuery calculateCostQuery)
        {
            var cost = await _mediator.Send(calculateCostQuery);

            return Ok(cost);
        }
    }
}
