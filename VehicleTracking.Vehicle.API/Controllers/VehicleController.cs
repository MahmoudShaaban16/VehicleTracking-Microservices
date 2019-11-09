using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleTracking.Vehicle.API.Queries;

namespace VehicleTracking.Customer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediatorBus;

        public VehicleController(IMediator mediatorBus)
        {
            _mediatorBus = mediatorBus;
        }

        // GET Vehicles by Customer Id and Vehicle Status
        [HttpGet]
        public async Task<ActionResult> Get(int customerId)
        {
            var result = await _mediatorBus.Send(new GetVehiclesByCustomerQuery() { CustomerId = customerId});
            return new JsonResult(result);
        }


    }
}