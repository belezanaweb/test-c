using System.Collections;
using System.Collections.Generic;

namespace TesteVagaBoticario.Negocio.Interfaces
{
    public interface IRepository<TObj>
    {
        void Update(TObj objeto);
        TObj Get(int id);
        void Remove(TObj objeto);
        void Save(TObj objeto);
        IList GetAll();
    }
}
