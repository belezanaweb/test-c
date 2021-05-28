using Inventory.Core.Data;
using Inventory.Infrastructure.Database.Context;
using NetHacksPack.Core;
using System;
using System.Collections.Generic;

namespace Inventory.Infrastructure.Database.Data
{
    class EFStorageRepository : IStorageRepository
    {
        private readonly ApplicationContext applicationContext;

        public EFStorageRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public Result<bool> Add<T>(T item)
        {
            try
            {
                applicationContext.Add(item);
                applicationContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return new Result<bool>(false, new[] { ex.Message, ex.StackTrace });
            }
        }

        public Result<bool> Remove<T>(T item)
        {
            try
            {
                applicationContext.Remove(item);
                applicationContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return new Result<bool>(false, new[] { ex.Message, ex.StackTrace});
            }
        }

        public Result<bool> Update<T>(T item)
        {
            try
            {
                applicationContext.Update(item);
                applicationContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return new Result<bool>(false, new[] { ex.Message, ex.StackTrace });
            }
        }
    }
}
