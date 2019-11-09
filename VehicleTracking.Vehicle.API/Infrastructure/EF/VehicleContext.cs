using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VehicleTracking.Vehicle.API.Infrastructure.EF
{
    public  class VehicleContext:DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options)
        {
        }
        public DbSet<Models.Vehicle> Vehicles { get; set; }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Models.Vehicle>().HasKey(e=>e.Id);
            builder.Entity<Models.Vehicle>().Property(e => e.Id).UseSqlServerIdentityColumn();
        }
    }
}
