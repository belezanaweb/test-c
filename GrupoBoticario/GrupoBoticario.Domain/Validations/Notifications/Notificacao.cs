namespace GrupoBoticario.Domain.Validations.Notifications
{
    public sealed class Notificacao
    {
        public string Propriedade { get; set; }
        public string Mensagem { get; set; }

        public Notificacao(
            string propriedade,
            string mensagem)
        {
            Propriedade = propriedade;
            Mensagem = mensagem;
        }
    }
}
