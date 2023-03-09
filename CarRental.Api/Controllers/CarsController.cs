using CarRental.Domain.Entities;
using CarRental.Persistance.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CarRental.Application.Functions.Cars.Queries.GetCarDto;
using CarRental.Application.Functions.Cars.Queries.GetAllCars;
using CarRental.Application.Functions.Cars.Queries.GetCarById;

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
            var cars = await _mediator.Send(new GetAllCarsQuery());

            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetCarById([FromRoute] int id)
        {
            var car = await _mediator.Send(new GetCarByIdQuery() { Id = id });

            return Ok(car);
        }
    }
}