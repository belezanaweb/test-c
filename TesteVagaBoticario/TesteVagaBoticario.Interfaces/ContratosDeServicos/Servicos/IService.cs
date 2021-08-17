using System;
using System.Collections.Generic;
using System.Text;

namespace TesteVagaBoticario.Interfaces.ContratosDeServicos.Servicos
{
    public interface IService<TDto, TObj>
        where TObj : class
        where TDto : class
    {
        TDto Get(int codigo);
        void Save(TDto dto);
        void Update(TDto dto);
        void Remove(int codigo);
    }
}
