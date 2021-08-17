using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteVagaBoticario.Negocio.Validadores
{
    public abstract class ValidacoesObjeto<TObj>: AbstractValidator<TObj> 
        where TObj : class
    {
        public abstract void AssineRegrasComuns();

        public virtual void AssineRegraDeInsercao()
        {
            this.AssineRegrasComuns();
        }
        public virtual void AssineRegrasDeAlteracao()
        {
            this.AssineRegrasComuns();
        }
    }
}
