using Microsoft.EntityFrameworkCore;
using PSCoreFundamentals.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSCoreFundamentals.Data
{
    public class CoreFundaDbContext : DbContext
    {
        public CoreFundaDbContext(DbContextOptions<CoreFundaDbContext> options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
