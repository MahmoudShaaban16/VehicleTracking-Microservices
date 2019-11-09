using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleTracking.VehiclePing.API.Queries;

namespace VehicleTracking.VehiclePing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclePingController : ControllerBase
    {
        private readonly IMediator _mediatorBus;

        public VehiclePingController(IMediator mediatorBus)
        {
            _mediatorBus = mediatorBus;
        }

        // GET Vehicles Ping status by Vehicle Id
        [HttpGet]
        public async Task<ActionResult> Post(int vehicleId)
        {
            var getVehicleStatusQuery = new GetVehicleStatusQuery() {VehicleId=vehicleId};
            var result = await _mediatorBus.Send(getVehicleStatusQuery);
            return new JsonResult(result);
        }


    }
}