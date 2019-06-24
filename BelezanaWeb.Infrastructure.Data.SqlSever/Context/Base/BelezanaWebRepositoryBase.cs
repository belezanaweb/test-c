using BelezanaWeb.Infrastructure.Data.Context;
using BelezanaWeb.Interface.Repository.Base;
using BelezanaWeb.Model;
using BelezanaWeb.Model.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BelezanaWeb.Infrastructure.Data.SqlSever
{
    public class BelezanaWebRepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : BaseEntity
    {
        private DbContextOptionsBuilder<BelezanaWebContext> _optionsBuilder;
        //protected DbContext databaseContext { get; }
        protected BelezanaWebContext databaseContext { get; }
        protected DbSet<T> Table;



        public BelezanaWebRepositoryBase()
        {
            _optionsBuilder = new DbContextOptionsBuilder<BelezanaWebContext>();
            _optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            //_optionsBuilder.UseInMemoryDatabase();

            databaseContext = new BelezanaWebContext(_optionsBuilder.Options);
            Table = databaseContext.Set<T>();
        }

        public virtual T GetById(long? id)
        {
            return Table.AsNoTracking().FirstOrDefault(x => x.Id == id.Value);
        }

        public IEnumerable<T> GetAll()
        {
            return Table.AsNoTracking();
        }

        public IEnumerable<T> GetAllActive()
        {
            return Table.AsNoTracking().Where(x => x.Active);
        }

        public IEnumerable<T> GetBy(Expression<Func<T, bool>> expression)
        {
            return expression == null ? Table.AsNoTracking() : Table.Where(expression).AsNoTracking();
        }
        public int Total(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
                return Table.AsNoTracking().Count();

            return Table.Where(expression).AsNoTracking().Count();
        }

        /// <summary>
        /// Persiste o objeto no banco de dados.
        /// </summary>
        /// <param name="model">A entidade a ser persistida.</param>
        public void Save(T model)
        {
            if (model == null) return;

            try
            {
                if (model.Id.GetHashCode() == 0)
                {
                    model.Created = DateTimeExtensions.GetBrazilianDate();
                    Table.Add(model);
                }
                else
                {
                    model.Updated = DateTimeExtensions.GetBrazilianDate();
                    Update(model);
                }

                databaseContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Save or update the entity on the database.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <returns></returns>
        public Result<T> SaveSync(T model)
        {
            var result = new Result<T>();

            if (model == null)
            {
                result.Success = false;
                result.FriendlyMessage = "Model is null.";

                return result;
            }


            try
            {
                if (model.Id.GetHashCode() == 0)
                {
                    model.Created = DateTimeExtensions.GetBrazilianDate();
                    Table.Add(model);
                }
                else
                {
                    model.Updated = DateTimeExtensions.GetBrazilianDate();
                    Update(model);
                }

                databaseContext.SaveChanges();

                result.Success = true;
                result.Objects.Add(model);
            }
            catch (SqlException sqlEx)
            {
                result.Success = false;
                result.FriendlyMessage = "SQL exception.";
                result.Error = sqlEx;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.FriendlyMessage = "SQL exception.";
                result.Error = ex;
            }

            return result;
        }

        /// <summary>
        /// Atualiza um objeto no banco de dados.
        /// </summary>
        /// <param name="model">A entidade a ser persistida.</param>
        private void Update(T model)
        {
            try
            {
                // We query local context first to see if it's there.
                var modelAlreadyAttach = Table.Local.FirstOrDefault(entry => entry.Id.Equals(model.Id));

                // We have it in the context, need to update.
                if (modelAlreadyAttach == null)
                {
                    // If it's not found locally, we can attach it by setting state to modified.
                    // This would result in a SQL update statement for all fields
                    // when SaveChanges is called. 
                    var entry = databaseContext.Entry(model);
                    entry.State = EntityState.Modified;
                }
                else
                {
                    var attachedEntry = databaseContext.Entry(modelAlreadyAttach);
                    attachedEntry.CurrentValues.SetValues(model);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void Remove(T obj)
        {
            Table.Remove(obj);
        }

        public void Rollback()
        {
            try
            {
                if (databaseContext != null)
                {
                    databaseContext.ChangeTracker.Entries()
                        .ToList()
                        .ForEach(entry => entry.State = EntityState.Unchanged);
                }
            }
            catch
            {
            }
        }

        public void Dispose()
        {
            if (databaseContext != null)
                databaseContext.Dispose();

            GC.SuppressFinalize(this);
        }


        public Task<int> SaveChangesAsync()
        {
            this.ChangeState();
            this.SetModifiedDate();
            return databaseContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            this.SetModifiedDate();
            return databaseContext.SaveChanges();
        }

        private void SetModifiedDate()
        {
            foreach (var item in databaseContext.ChangeTracker.Entries())
            {
                if (item.State == EntityState.Modified)
                {
                    ((BaseEntity)item.Entity).Updated = DateTimeExtensions.GetBrazilianDate();
                }
            }
        }

        private void ChangeState()
        {
            foreach (var item in databaseContext.ChangeTracker.Entries())
            {
                item.State = ((BaseEntity)item.Entity).IsNew() ? EntityState.Added : EntityState.Modified;
            }
        }
    }
}
