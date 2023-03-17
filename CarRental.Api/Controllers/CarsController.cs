using CarRental.Domain.Entities;
using CarRental.Persistance.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CarRental.Application.Functions.Cars.Queries.GetCarDto;
using CarRental.Application.Functions.Cars.Queries.GetAllCars;
using CarRental.Application.Functions.Cars.Queries.GetCarById;
using CarRental.Application.Functions.Cars.Queries.GetCarsByAddressId;
using CarRental.Application.Functions.Cars.Commands.AddCar;
using CarRental.Application.Functions.Cars.Commands.UpdateCar;
using CarRental.Application.Functions.Cars.Commands.DeleteCar;

namespace CarRental.Api.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarDto>>> GetAllCars()
        {
            var result = await _mediator.Send(new GetAllCarsQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetCarById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetCarByIdQuery() { Id = id });

            return Ok(result);
        }

        [HttpGet("getByAddressId/{id}")]
        public async Task<ActionResult<List<CarDto>>> GetCarsByAddressId([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetCarsByAddressIdQuery() { Id = id });

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult<int>> AddCar([FromQuery] AddCarCommand addCar)
        {
            var newCar = await _mediator.Send(addCar);

            return Created($"New car id = {newCar}", null);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Unit>> UpdateCar([FromQuery] UpdateCarCommand updateCar, [FromRoute] int id, CancellationToken cancellationToken)
        {
            updateCar.Id = id;

            var car = await _mediator.Send(updateCar);

            return Ok("Car updated");
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<int>> DeleteCarById([FromRoute] int id)
        {
            var car = await _mediator.Send(new DeleteCarCommand() { Id = id });

            return Ok($"Deleted car id = {car}");
        }
    }
}