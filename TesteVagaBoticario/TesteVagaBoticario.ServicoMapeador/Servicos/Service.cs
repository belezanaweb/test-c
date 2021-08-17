using FluentValidation;
using System;
using System.Linq;
using TesteVagaBoticario.Interfaces.ContratosDeServicos.Servicos;
using TesteVagaBoticario.Negocio.Interfaces;
using TesteVagaBoticario.Negocio.Validadores;
using TesteVagaBoticario.ServicoMapeador.Infraestrutura;
using TesteVagaBoticario.ServicoMapeador.Infraestutura;

namespace TesteVagaBoticario.ServicoMapeador.Servicos
{
    public abstract class Service<TDto, TObj> : IService<TDto, TObj>
        where TObj : class
        where TDto : class
    {

        protected Service(ContextoBD contexto)
        {
            this.contexto = contexto;
        }

        protected ContextoBD contexto;

        protected abstract IConverter<TDto, TObj> GetConverter();

        protected abstract ValidacoesObjeto<TObj> GetValidator();

        protected abstract IRepository<TObj> GetRepository();

        protected abstract TObj GetObjet(TDto dto);

        public TDto Get(int codigo)
        {
            var objeto = this.GetRepository().Get(codigo);

            return this.GetConverter().ConverterToDto(objeto);
        }

        public void Remove(int codigo)
        {
            var objeto = this.GetRepository().Get(codigo);

            if (objeto == null)
            {
                throw new Exception("Item não encontrado!");
            }

            this.GetRepository().Remove(objeto);
        }

        public void Save(TDto dto)
        {
            var objeto = this.GetConverter().ConverterToObject(dto);

            this.ExecuteValidacaoInsercao(objeto);

            this.GetRepository().Save(objeto);
        }

        public virtual void Update(TDto dto)
        {
            var objeto = this.GetObjet(dto);

            if (objeto == null)
            {
                throw new Exception("Item não encontrado!");
            }

            var objetoUpdate = this.GetConverter().ConverterToUpdate(objeto, dto);

            this.ExecuteValidacaoAlteracao(objetoUpdate);

            this.GetRepository().Update(objetoUpdate);
        }

        private void ExecuteValidacaoInsercao(TObj objeto)
        {
            var validacao = this.GetValidator();

            validacao.AssineRegraDeInsercao();

            this.ExecuteValidacao(objeto, validacao);
        }

        private void ExecuteValidacaoAlteracao(TObj objeto)
        {
            var validacao = this.GetValidator();

            validacao.AssineRegrasDeAlteracao();

            this.ExecuteValidacao(objeto, validacao);
        }

        protected void ExecuteValidacao(TObj objeto, IValidator validador)
        {
            var context = new ValidationContext<TObj>(objeto);
            var retornoValidacao = validador.Validate(context);

           if (!retornoValidacao.IsValid)
           {
              throw new Exception(retornoValidacao.Errors.FirstOrDefault().ErrorMessage);
           }
        }
    }
}
