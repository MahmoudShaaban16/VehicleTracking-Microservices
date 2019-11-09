using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleTracking.VehicleConnection.API.Commands;

namespace VehicleTracking.VehicleConnection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleConnectionController : ControllerBase
    {
        private readonly IMediator _mediatorBus;

        public VehicleConnectionController(IMediator mediatorBus)
        {
            _mediatorBus = mediatorBus;
        }

        // Posting a new connection from Vehicle Device
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] int vehicleId)
        {
            var recordNewConnectionCommand = new RecordNewConnectionCommand() { ConnectionDate = DateTime.Now, VehicleId = vehicleId, VehicleIP = Request.HttpContext.Connection.RemoteIpAddress.ToString() };
            var result = await _mediatorBus.Send(recordNewConnectionCommand);
            return new JsonResult(result);
        }


    }
}