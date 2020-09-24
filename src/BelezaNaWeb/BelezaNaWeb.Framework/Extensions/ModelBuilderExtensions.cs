using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using BelezaNaWeb.Domain.Interfaces.Entities;
using BelezaNaWeb.Framework.Data.Configurations;

namespace BelezaNaWeb.Framework.Extensions
{
    internal static class ModelBuilderExtensions
    {
        #region Extension Methods

        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityConfiguration<TEntity> entityConfiguration)
            where TEntity : class, IEntity
        {
            modelBuilder.Entity<TEntity>(entityConfiguration.Configure);
            modelBuilder.Entity<TEntity>().HasData(entityConfiguration.Seed());
        }

        public static void LoadAllConfigurations(this ModelBuilder modelBuilder)
        {
            var assemblies = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x =>
                       x.Name.EndsWith("Configuration", StringComparison.OrdinalIgnoreCase)
                    && x.Namespace.EndsWith("Data.Configurations", StringComparison.OrdinalIgnoreCase)
                );

            foreach (var assembly in assemblies)
            {
                dynamic instance = Activator.CreateInstance(assembly);
                ModelBuilderExtensions.AddConfiguration(modelBuilder, instance);
            }
        }

        public static void RemoveCascadeDeleteConvention(this ModelBuilder modelBuilder)
        {
            var imutableEntities = modelBuilder.Model.GetEntityTypes()
                .Where(e => !e.IsOwned())
                .SelectMany(e => e.GetForeignKeys());

            foreach (var relationship in imutableEntities)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        #endregion
    }
}
