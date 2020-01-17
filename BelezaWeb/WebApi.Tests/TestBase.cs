using DataAccess.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApi.Tests
{
    /// <summary>
    /// Base for tests
    /// </summary>
    public class TestBase
    {
        #region Fields

        /// <summary>
        /// Database Options
        /// </summary>
        public DbContextOptions DatabaseOptions { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TestBase()
        {
            DatabaseOptions = new DbContextOptionsBuilder<BelezaWebContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging(true)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
        }

        #endregion
    }
}
