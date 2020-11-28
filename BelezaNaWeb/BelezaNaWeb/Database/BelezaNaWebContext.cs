using BelezaNaWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.Database
{
    public class BelezaNaWebContext : DbContext
    {
        public BelezaNaWebContext(DbContextOptions<BelezaNaWebContext> options) : base(options)
        {
           
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Inventory> Inventarios { get; set; }
        public DbSet<Warehouse> Locais { get; set; }
    }
}
