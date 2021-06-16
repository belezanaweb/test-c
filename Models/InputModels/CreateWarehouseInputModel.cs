using Newtonsoft.Json;

namespace TesteBelezaNaWeb.API.Models.InputModels
{
    public class CreateWarehouseInputModel
    {

        public string locality { get;  set; }
        public int quantity { get;  set; }
        public string type { get;  set; }
    }
}

