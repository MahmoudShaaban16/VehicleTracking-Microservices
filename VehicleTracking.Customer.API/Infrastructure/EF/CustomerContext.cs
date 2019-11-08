using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VehicleTracking.Customer.API.Infrastructure.EF
{
    public  class CustomerContext:DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }
        public DbSet<Models.Customer> CatalogItems { get; set; }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Models.Customer>().HasKey(e=>e.Id);
            builder.Entity<Models.Customer>().Property(e=>e.Id).ForSqlServerUseSequenceHiLo("customer_hilo")
               .IsRequired();
        }
    }
}
