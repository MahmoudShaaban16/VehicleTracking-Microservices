using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracking.Core.Infrastructure;
using VehicleTracking.Customer.API.Models;
namespace VehicleTracking.Customer.API.Infrastructure.EF
{
   public interface ICustomerRepository:IRepository
    {
        List<Models.Customer> Get();
    }
}
