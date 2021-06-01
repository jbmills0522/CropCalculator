using System;
using Microsoft.EntityFrameworkCore;
using TomatoCalculator.Shared.Models;

namespace TomatoCalculator.Server.Data
{
    public class TomatoCalculatorContext : DbContext
    {
        public TomatoCalculatorContext(DbContextOptions<TomatoCalculatorContext> options) : base(options)
        {        }
            public DbSet<Tomato> Tomatoes { get; set; }
            public DbSet<Shipping> ShippingLoads { get; set; }
            public DbSet<RouteInformation> RouteInformations { get; set; }
            public DbSet<DriverInformation> DriverInformations { get; set; }
    }
}