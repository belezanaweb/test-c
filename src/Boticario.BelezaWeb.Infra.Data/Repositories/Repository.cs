using Boticario.BelezaWeb.Domain.Entities;
using Boticario.BelezaWeb.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Boticario.BelezaWeb.Infra.Data.Repositories
{
	public abstract class Repository : IRepository
	{
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected abstract void Dispose(bool disposing);
	}

	public class Repository<TEntity> : Repository, IRepository<TEntity> where TEntity : Entity
	{
		protected readonly DbContext Context;

		protected Repository(DbContext context)
		{
			Context = context;
		}

		public async Task<TEntity> Find(int id)
		{
			return await Context.Set<TEntity>().FindAsync(id);
		}

		public IQueryable<TEntity> List(Expression<Func<TEntity, bool>> expression)
		{
			return expression is null
				? Context.Set<TEntity>().AsNoTracking()
				: Context.Set<TEntity>().Where(expression).AsNoTracking();
		}

		public void Add(TEntity entity)
		{
			Context.Set<TEntity>().Add(entity);
		}

		public void Update(TEntity entity)
		{
			Context.Set<TEntity>().Update(entity);
		}

		public void Delete(TEntity entity)
		{
			Context.Set<TEntity>().Remove(entity);
		}

		public async Task<int> Save()
		{
			return await Context.SaveChangesAsync();
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposing) return;
			Context?.Dispose();
		}
	}
}
