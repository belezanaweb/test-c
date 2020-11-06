using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Boticario.BelezaWeb.Application.ViewModels.Product
{
	public class ProductViewModel
	{
		[Key] public int Sku { get; set; }

		[Required(ErrorMessage = "Nome é obrigatório")]
		[MaxLength(500, ErrorMessage = "Máximo 500 caracteres")]
		public string Name { get; set; }

		[JsonIgnore] public bool IsMarketable { get; set; }

		public InventoryViewModel Inventory { get; set; }

		[JsonIgnore] public IEnumerable<string> Errors { get; set; }
	}
}
