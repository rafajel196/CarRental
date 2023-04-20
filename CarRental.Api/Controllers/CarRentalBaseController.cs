using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    public class CarRentalBaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public CarRentalBaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
