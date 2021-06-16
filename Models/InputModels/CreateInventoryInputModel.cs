using System.Collections.Generic;


namespace TesteBelezaNaWeb.API.Models.InputModels
{
    public class CreateInventoryInputModel
    {
        public IList<CreateWarehouseInputModel> warehouses { get; set; }
    }
}
