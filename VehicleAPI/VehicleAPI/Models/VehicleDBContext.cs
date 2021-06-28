using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleAPI.Models;

namespace VehicleAPI.Models
{
    public class VehicleDBContext:DbContext
    {
        public VehicleDBContext(DbContextOptions<VehicleDBContext> options) : base(options)
        {

        }

        public DbSet<VehicleDetail> VehicleDetails { get; set; }

        public DbSet<VehicleMaker> VehicleMakers { get; set; }
    }
}
