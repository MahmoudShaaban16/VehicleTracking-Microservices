﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracking.Customer.API.ViewModels;

namespace VehicleTracking.Customer.API.Queries
{
    public class GetAllCustomerNamesResult
    {
        public List<CustomerNameViewModel> CustomerNames { get; set; }
    }
}
