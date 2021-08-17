using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TesteVagaBoticario.Interfaces.ContratosDeServicos.Dados;
using TesteVagaBoticario.Interfaces.ContratosDeServicos.Servicos;
using TesteVagaBoticario.Negocio;
using TesteVagaBoticario.Negocio.Interfaces;
using TesteVagaBoticario.Negocio.Validadores;
using TesteVagaBoticario.ServicoMapeador.Infraestrutura;
using TesteVagaBoticario.ServicoMapeador.Infraestutura;
using TesteVagaBoticario.ServicoMapeador.Mapeadores.Repositorios;
using TesteVagaBoticario.ServicoMapeador.Servicos.Conversores;

namespace TesteVagaBoticario.ServicoMapeador.Servicos
{
    public class ServiceProduct : Service<DtoProduct, Product>, IServiceProduct
    {
        public ServiceProduct(ContextoBD contexto) : base(contexto)
        {
        }

        protected override IConverter<DtoProduct, Product> GetConverter()
        {
            return new ConverterProduct();
        }

        protected override Product GetObjet(DtoProduct dto)
        {
            return this.GetRepository().Get(dto.Sku);
        }

        protected override IRepository<Product> GetRepository()
        {
            return new RepositoryProduct(this.contexto);
        }

        protected override ValidacoesObjeto<Product> GetValidator()
        {
            return new ValidacoesProduct((IRepositoryProduct)this.GetRepository());
        }
    }
}
