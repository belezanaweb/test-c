using System;

namespace BelezanaWeb.Model
{
    /// <summary>
    /// Propriedades e funções comuns aos modelos da aplicação.
    /// </summary>
    [Serializable]
    public class BaseEntity
    {
        /// <summary>
        /// Construtor.
        /// </summary>
        public BaseEntity()
        {
            this.Created = DateTime.UtcNow;
        }

        public long Id { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Indica se o objeto já existe na base ou não.
        /// </summary>
        /// <returns>Verdadeiro caso o objeto não exista no banco de dados (Id==0).</returns>
        public virtual bool IsNew()
        {
            return Id == 0;
        }
    }
}
