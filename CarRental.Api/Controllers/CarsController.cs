using CarRental.Domain.Entities;
using CarRental.Persistance.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CarRental.Application.Functions.Cars.Queries.GetAllCars;
using CarRental.Application.Functions.Cars.Queries.GetCarById;
using CarRental.Application.Functions.Cars.Queries.GetCarsByAddressId;
using CarRental.Application.Functions.Cars.Commands.AddCar;
using CarRental.Application.Functions.Cars.Commands.UpdateCar;
using CarRental.Application.Functions.Cars.Commands.DeleteCar;
using CarRental.Application.DTOs;

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

        [HttpGet("address-id/{carAddressId}")]
        public async Task<ActionResult<List<CarDto>>> GetCarsByAddressId([FromRoute] int carAddressId)
        {
            var result = await _mediator.Send(new GetCarsByAddressIdQuery() { Id = carAddressId });

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<int>> AddCar([FromBody] AddCarCommand addCar)
        {
            var newCar = await _mediator.Send(addCar);

            return Created($"New car id = {newCar}", null);
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<Unit>> UpdateCar([FromBody] UpdateCarCommand updateCar, CancellationToken cancellationToken)
        {
            var car = await _mediator.Send(updateCar);

            return Ok("Car updated");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<int>> DeleteCarById([FromRoute] int id)
        {
            var car = await _mediator.Send(new DeleteCarCommand() { Id = id });

            return Ok($"Deleted car id = {car}");
        }
    }
}