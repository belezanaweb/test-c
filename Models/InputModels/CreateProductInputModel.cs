
namespace TesteBelezaNaWeb.API.Models.InputModels
{
    public class CreateProductInputModel
    {
        public int sku { get;  set; }
        public string name { get;  set; }
        public CreateInventoryInputModel inventory { get; set; }
}
}
