using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.DatabaseContext
{
    /// <summary>
    /// Database context
    /// </summary>
    public class BelezaWebContext : DbContext
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="options"></param>
        public BelezaWebContext(DbContextOptions options) : base(options) { }

        #endregion

        #region DbSets For tables

        /// <summary>
        /// Products
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// Warehouses
        /// </summary>
        public DbSet<Warehouse> Warehouses { get; set; }

        #endregion


        #region Events

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Collections for tables
            modelBuilder.Entity<Product>(entity => { entity.ToTable("TProduct"); });
            modelBuilder.Entity<Warehouse>(entity => { entity.ToTable("TWarehouse"); });
        }
        
        #endregion
    }
}
