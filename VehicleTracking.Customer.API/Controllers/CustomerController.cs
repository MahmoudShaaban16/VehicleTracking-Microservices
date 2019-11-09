using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleTracking.Customer.API.Queries;

namespace VehicleTracking.Customer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediatorBus;

        public CustomerController(IMediator mediatorBus)
        {
            _mediatorBus = mediatorBus;
        }

        // GET 
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _mediatorBus.Send(new GetAllCustomerNamesQuery());
            return new JsonResult(result);
        }


    }
}