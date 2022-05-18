using AutoMapper;
using Boticario.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Boticario.Data.Queries.Base
{
    public class BaseQuery<TDestination, TEntity>
        where TDestination : class
        where TEntity : class
    {
        protected readonly DefaultContext DbContext;
        protected readonly IQueryable<TEntity> DbQuery;
        protected readonly IMapper Mapper;
        protected readonly DbConnection Connection;

        public BaseQuery(DefaultContext context, IMapper imapper)
        {
            DbContext = context;
            DbQuery = DbContext.Set<TEntity>().AsNoTracking();
            Mapper = imapper;
            Connection = DbContext.Database.GetDbConnection();
        }

        protected async Task<List<TDestination>> GetList(Expression<Func<TEntity, bool>> filtro = null)
        {
            var query = DbQuery.AsNoTracking().AsQueryable();

            if (filtro != null)
                query = query.Where(filtro);

            return await Mapper.ProjectTo<TDestination>(query).ToListAsync();
        }

        protected async Task<List<TDestination>> GetList(IQueryable<TEntity> query)
        {
            return await Mapper.ProjectTo<TDestination>(query).ToListAsync();
        }

        protected async Task<TDestination> Get(Expression<Func<TEntity, bool>> filtro)
        {
            var query = DbQuery.AsNoTracking().AsQueryable();

            if (filtro != null)
                query = query.Where(filtro);

            return await Mapper.ProjectTo<TDestination>(query).FirstOrDefaultAsync(); 
        }
    }

    public class BaseQuery
    {
        protected readonly DefaultContext DbContext;
        protected readonly DbConnection Connection;

        public BaseQuery(DefaultContext context)
        {
            DbContext = context;
            Connection = DbContext.Database.GetDbConnection();
        }
    }
}