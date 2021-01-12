namespace GrupoBoticarioTeste.Business.ViewModels
{
    public class SearchProductViewModel
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public bool IsMarketable { get; set; }
        public InventoryViewModel Inventory { get; set; }
    }
}
