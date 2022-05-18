namespace Boticario.Infra.Data.Entities
{
    public class TabelaEstoque
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }

        public string Local { get; set; }

        public int Quantidade { get; set; }

        public string Tipo { get; set; }

        public virtual TabelaProduto Produto { get; set; }
    }
}
