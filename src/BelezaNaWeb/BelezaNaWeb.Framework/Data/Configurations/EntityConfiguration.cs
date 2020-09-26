using System;
using System.Collections.Generic;
using BelezaNaWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BelezaNaWeb.Framework.Data.Configurations
{
    internal abstract class EntityConfiguration<TEntity>
        where TEntity : class, IEntity
    {
        #region Public Abstract Methods

        public abstract void Configure(EntityTypeBuilder<TEntity> builder);

        public virtual IEnumerable<TEntity> Seed() => Array.Empty<TEntity>();

        #endregion
    }
}
