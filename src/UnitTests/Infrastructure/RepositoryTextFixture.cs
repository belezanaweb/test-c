using Core.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Infrastructure
{
    public abstract class RepositoryTextFixture
    {
        protected AppDbContext _dbContext;

        protected Repository<T> GetRepository<T>() where T : BaseEntity
        {
            _dbContext = new AppDbContext();
            return new Repository<T>(_dbContext);
        }
    }
}
