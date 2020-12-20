using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TesteBotica.DataManager
{
    public class ProductDataManager
    {
        public List<Product> Load()
        {
            
                using (StreamReader r = new StreamReader("inventory.json"))
                {
                    string json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Product>>(json);
                }
            
        }
    }
}
