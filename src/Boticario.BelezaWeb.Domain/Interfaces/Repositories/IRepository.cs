using Boticario.BelezaWeb.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Boticario.BelezaWeb.Domain.Interfaces.Repositories
{
	public interface IRepository : IDisposable
	{
	}

	public interface IRepository<TEntity> : IRepository where TEntity : Entity
	{
		Task<TEntity> Find(int id);
		IQueryable<TEntity> List(Expression<Func<TEntity, bool>> expression = null);
		void Add(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity entity);
		Task<int> Save();
	}
}
