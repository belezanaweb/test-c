using BoticarioAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoticarioAPI.Infra.Context
{
    public class BoticarioContext : DbContext
    {
        public BoticarioContext(DbContextOptions<BoticarioContext> options)
        : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
