using System;
using System.Collections.Generic;
using System.Text;
using TesteVagaBoticario.Interfaces.ContratosDeServicos.Dados;

namespace TesteVagaBoticario.Interfaces.ContratosDeServicos.Servicos
{
    public interface IServiceProduct
    {
        DtoProduct Get(int codigo);
        void Save(DtoProduct dto);
        void Update(DtoProduct dto);
        void Remove(int sku);
    }
}
