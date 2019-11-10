using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VehicleTracking.VehicleConnection.API.Commands;

namespace VehicleTracking.VehicleConnection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleConnectionController : ControllerBase
    {
        private readonly IMediator _mediatorBus;
        private readonly ILogger<VehicleConnectionController> _logger;
        public VehicleConnectionController(IMediator mediatorBus,ILogger<VehicleConnectionController> logger)
        {
            _logger = logger;
            _mediatorBus = mediatorBus;
        }

        // Posting a new connection from Vehicle Device
        [HttpPost("{vehicleId}")]
        public async Task<ActionResult> Post(int vehicleId)
        {
            try
            {
                var recordNewConnectionCommand = new RecordNewConnectionCommand() { ConnectionDate = DateTime.Now, VehicleId = vehicleId, VehicleIP = Request.HttpContext.Connection.RemoteIpAddress.ToString() };
                var result = await _mediatorBus.Send(recordNewConnectionCommand);
                return new JsonResult(result);
            }
            catch(Exception ex)
            {
                _logger.LogError("An error while posting a new vehicle connection with details", ex);
                throw;
            }
            
        }


    }
}