namespace GrupoBoticario.Domain.Validations.Contracts
{
    public partial class Contrato
    {
        public Contrato VerificaSeFalso(bool valor, string propriedade, string mensagem)
        {
            if (valor is true)
                InserirNotificacao(propriedade, mensagem);

            return this;
        }

        public Contrato VerificaeSeVerdadeiro(bool valor, string propriedade, string mensagem) => 
            VerificaSeFalso(!valor, propriedade, mensagem);
    }
}
