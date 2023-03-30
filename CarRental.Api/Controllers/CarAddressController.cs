using CarRental.Application.Functions.CarAddresses.Queries.GetAllCarsAddreses;
using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressByCarId;
using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressById;
using CarRental.Application.Functions.CarAddresses.Queries.CarAddressModelCommon;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.Functions.CarAddresses.Commands.AddCarAddress;
using CarRental.Application.Functions.CarAddresses.Commands.UpdateCarAddress;
using CarRental.Application.Functions.CarAddresses.Commands.DeleteCarAddress;

namespace CarRental.Api.Controllers
{
    [ApiController]
    [Route("api/car-address")]
    public class CarAddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarAddressDto>>> GetAllCarsAddresses()
        {
            var addresses = await _mediator.Send(new GetAllCarsAddressesQuery());

            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarAddressDto>> GetCarAddressById([FromRoute] int id)
        {
            var address = await _mediator.Send(new GetCarAddressByIdQuery() { Id = id });

            return Ok(address);
        }

        [HttpGet("car/{carId}")]
        public async Task<ActionResult<CarAddressDto>> GetCarAddressByCarId([FromRoute] int carId)
        {
            var address = await _mediator.Send(new GetCarAddressByCarIdQuery() { CarId = carId });

            return Ok(address);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddCarAddress([FromBody] AddCarAddressCommand addCarAddress)
        {
            var result = await _mediator.Send(addCarAddress);

            return Created($"Car address id = {result}", null);
        }

        [HttpPut]
        public async Task<ActionResult<Unit>> UpdateCarAddress([FromBody] UpdateCarAddressCommand updateCarAddress)
        {
            var result = await _mediator.Send(updateCarAddress);

            return Ok("Car address updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteCarAddress([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteCarAddressCommand() { Id = id });

            return Ok("Car address deleted");
        }
    }
}
