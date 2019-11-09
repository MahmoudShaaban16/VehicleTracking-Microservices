using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracking.Core.Infrastructure;
using VehicleTracking.Customer.API.Infrastructure.EF;

namespace VehicleTracking.Customer.API.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public List<Models.Customer> Get()
        {
            return _context.Customers.ToList();
        }
    }
}
