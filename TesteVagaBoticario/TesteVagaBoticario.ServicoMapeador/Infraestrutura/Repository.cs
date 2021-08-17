using System.Collections;
using System.Collections.Generic;
using TesteVagaBoticario.Negocio.Interfaces;

namespace TesteVagaBoticario.ServicoMapeador.Infraestutura
{
    public abstract class Repository<TObj> : IRepository<TObj> where TObj : class
    {
        protected ContextoBD Contexto { get; set; }

        public Repository(ContextoBD contexto)
        {
            this.Contexto = contexto;
        }

        public void Update(TObj objeto)
        {
            this.Contexto.Set<TObj>().UpdateRange(objeto);
            this.Contexto.SaveChanges();
        }

        public virtual TObj Get(int id)
        {
            return this.Contexto.Set<TObj>().Find(id);
        }

        public void Remove(TObj objeto)
        {
            this.Contexto.Set<TObj>().RemoveRange(objeto);
            this.Contexto.SaveChanges();
        }

        public IList GetAll()
        {
            var lista = new ArrayList();
            foreach(var objeto in this.Contexto.Set<TObj>())
            {
                lista.Add(objeto);
            }
            return lista;
        }

        public void Save(TObj objeto)
        {
            this.Contexto.Set<TObj>().Add(objeto);
            this.Contexto.SaveChanges();
        }
    }
}
