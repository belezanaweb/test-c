namespace Desafio.Domain.Command
{
    public abstract class ProductCommand : Command
    {
        public int Sku { get; set; }
        public string Name { get; set; }
    }

}
