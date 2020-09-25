using AutoMapper;

namespace BelezaNaWeb.Api.Infrastructure.Mappings
{
    public abstract class GenericMapping<TEntity> : Profile
        where TEntity : class
    {
        #region Constructors

        public GenericMapping(string profileName)
            : base(profileName) => Configure();

        #endregion

        #region Public Abstract Methods

        public abstract void Configure();

        #endregion
    }
}
