using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWebAPI.Repo
{
    public static class RepoExtensions
    {
        public static bool TryGetBySku<T>(this IRepository<T> repo, int sku, out T r) where T : class, Model.IEntity
        {
            r = repo.Get().FirstOrDefault(x => x.sku == sku);
            return r != null;
        }

        public static T GetBySku<T>(this IRepository<T> repo, int sku) where T : class, Model.IEntity
        {
            if (!repo.TryGetBySku(sku, out var r))
            {
                throw new KeyNotFoundException($"O objeto do tipo '{typeof(T).Name}' com a chave '{sku}' não foi encontrado");
            }

            return r;
        }
    }
}
