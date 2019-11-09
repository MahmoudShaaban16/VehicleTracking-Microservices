using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace VehicleTracking.Customer.API.Queries
{
    public class GetAllCustomerNamesQuery: IRequest<GetAllCustomerNamesQueryResult>
    {
    }
}
