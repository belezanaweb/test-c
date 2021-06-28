
namespace GrupoBoticario.Domain.Validations.Contracts
{
    public partial class Contrato
    {
        public Contrato VerificaeSeNaoNuloOuVazio(string valor, string propriedade, string mensagem) 
        {
            if (string.IsNullOrEmpty(valor))
                InserirNotificacao(propriedade, mensagem);

            return this;
        }

        public Contrato VerificaeSeNaoNuloOuEspacoEmBranco(string valor, string propriedade, string mensagem)
        {
            if (string.IsNullOrWhiteSpace(valor))
                InserirNotificacao(propriedade, mensagem);

            return this;
        }
    }
}
