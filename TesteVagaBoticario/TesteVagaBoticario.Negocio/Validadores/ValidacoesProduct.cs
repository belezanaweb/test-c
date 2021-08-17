using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TesteVagaBoticario.Negocio;
using TesteVagaBoticario.Negocio.Interfaces;


namespace TesteVagaBoticario.Negocio.Validadores
{
    public class ValidacoesProduct : ValidacoesObjeto<Product>
    {
        IRepositoryProduct repositorio;

        public ValidacoesProduct(IRepositoryProduct repository)
        {
            this.repositorio = repository;
        }
        public override void AssineRegrasComuns()
        {
            this.AssineValidacaoSku();
            this.AssineValidacaoName();
        }

        public override void AssineRegraDeInsercao()
        {
            this.AssineRegraMesmoSku();
            this.AssineRegrasComuns();
        }
        public void AssineValidacaoSku()
        {
            RuleFor(Processo => Processo.Sku)
                    .NotEmpty()
                    .WithMessage("Informe o sku do produto.");
        }

        public void AssineValidacaoName()
        {
            RuleFor(Processo => Processo.Sku)
                    .NotEmpty()
                    .WithMessage("Informe o nome do produto.");
        }

        public void AssineRegraMesmoSku()
        {
            RuleFor(produto => produto)
                    .Must(produto => !repositorio.Exist(produto.Sku))
                    .WithMessage("Dois produtos são considerados iguais se os seus skus forem iguais.");
        }
    }
}
