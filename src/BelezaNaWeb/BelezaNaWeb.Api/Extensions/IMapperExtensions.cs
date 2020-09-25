using AutoMapper;
using BelezaNaWeb.Domain.Interfaces.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.Api.Extensions
{
    public static class IMapperExtensions
    {
        //#region Extension Methods - ConvertEntityToSchema

        //public static TSchema ConvertEntityToSchema<TSchema, TEntity>(this IMapper mapper, TEntity entity)
        //    where TSchema : class, ISchema
        //    where TEntity : class, IBaseEntity
        //{
        //    return mapper.Map<TEntity, TSchema>(entity);
        //}

        //public static TSchema ConvertEntityToSchema<TSchema>(this IMapper mapper, IBaseEntity entity)
        //    where TSchema : class, ISchema
        //{
        //    return (TSchema)mapper.Map(entity, entity.GetType(), typeof(TSchema));
        //}

        //public static IEnumerable<TSchema> ConvertEntityToSchema<TSchema, TEntity>(this IMapper mapper, IEnumerable<TEntity> entity)
        //    where TSchema : class, ISchema
        //    where TEntity : class, IBaseEntity
        //{
        //    return mapper.Map<IEnumerable<TEntity>, IEnumerable<TSchema>>(entity);
        //}

        //public static IEnumerable<TSchema> ConvertEntityToSchema<TSchema>(this IMapper mapper, IEnumerable<IBaseEntity> entity)
        //    where TSchema : class, ISchema
        //{
        //    return (IEnumerable<TSchema>)mapper.Map(entity, entity.GetType(), typeof(IEnumerable<TSchema>));
        //}

        //#endregion

        //#region Extension Methods - ConvertSchemaToEntity

        //public static TEntity ConvertSchemaToEntity<TEntity, TSchema>(this IMapper mapper, TSchema schema)
        //    where TSchema : class, ISchema
        //    where TEntity : class, IBaseEntity
        //{
        //    return mapper.Map<TSchema, TEntity>(schema);
        //}

        //public static TEntity ConvertSchemaToEntity<TEntity>(this IMapper mapper, ISchema schema)
        //    where TEntity : class, IBaseEntity
        //{
        //    return (TEntity)mapper.Map(schema, schema.GetType(), typeof(TEntity));
        //}

        //public static IEnumerable<TEntity> ConvertSchemaToEntity<TEntity, TSchema>(this IMapper mapper, IEnumerable<TSchema> schema)
        //    where TSchema : class, ISchema
        //    where TEntity : class, IBaseEntity
        //{
        //    return mapper.Map<IEnumerable<TSchema>, IEnumerable<TEntity>>(schema);
        //}

        //public static IEnumerable<TEntity> ConvertSchemaToEntity<TEntity>(this IMapper mapper, IEnumerable<ISchema> schema)
        //    where TEntity : class, IBaseEntity
        //{
        //    return (IEnumerable<TEntity>)mapper.Map(schema, schema.GetType(), typeof(IEnumerable<TEntity>));
        //}

        //#endregion

        #region Extension Methods - ConvertRequestToEntity

        public static TEntity ConvertRequestToEntity<TEntity, TRequest>(this IMapper mapper, TRequest request)
            where TEntity : class, IEntity
            where TRequest : class, IBaseRequest
        {
            return mapper.Map<TRequest, TEntity>(request);
        }

        public static TEntity ConvertRequestToEntity<TEntity>(this IMapper mapper, IBaseRequest request)
            where TEntity : class, IEntity
        {
            return (TEntity)mapper.Map(request, request.GetType(), typeof(TEntity));
        }

        public static IEnumerable<TEntity> ConvertRequestToEntity<TEntity, TRequest>(this IMapper mapper, IEnumerable<TRequest> request)
            where TEntity : class, IEntity
            where TRequest : class, IBaseRequest
        {
            return mapper.Map<IEnumerable<TRequest>, IEnumerable<TEntity>>(request);
        }

        public static IEnumerable<TEntity> ConvertRequestToEntity<TEntity>(this IMapper mapper, IEnumerable<IBaseRequest> request)
            where TEntity : class, IEntity
        {
            return (IEnumerable<TEntity>)mapper.Map(request, request.GetType(), typeof(IEnumerable<TEntity>));
        }

        #endregion
    }
}
