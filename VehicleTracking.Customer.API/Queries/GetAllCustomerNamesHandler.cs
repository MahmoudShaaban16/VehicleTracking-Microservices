using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VehicleTracking.Customer.API.Infrastructure.EF;
using VehicleTracking.Customer.API.ViewModels;

namespace VehicleTracking.Customer.API.Queries
{
    public class GetAllCustomerNamesHandler:IRequestHandler<GetAllCustomerNamesQuery, GetAllCustomerNamesQueryResult>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetAllCustomerNamesHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<GetAllCustomerNamesQueryResult> Handle(GetAllCustomerNamesQuery request,CancellationToken token)
        {
            List<Customer.API.Models.Customer> customers = _customerRepository.Get();
            List<CustomerNameViewModel> customerVMs = new List<CustomerNameViewModel>();
            customers.ForEach(c => customerVMs.Add(new CustomerNameViewModel() { CustomerId = c.Id, CustomerName = c.Name }));
            return new GetAllCustomerNamesQueryResult() { CustomerNames = customerVMs };
        }
    }
}
