using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VehicleTracking.Customer.API.Queries;

namespace VehicleTracking.Customer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediatorBus;
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(IMediator mediatorBus, ILogger<CustomerController> logger)
        {
            _mediatorBus = mediatorBus;
            _logger = logger;
        }

        // GET 
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _mediatorBus.Send(new GetAllCustomerNamesQuery());
                return new JsonResult(result);
            }
            catch(Exception ex)
            {
                _logger.LogError("An error occurred in getting customers api", ex);
                throw;
            }
        }


    }
}