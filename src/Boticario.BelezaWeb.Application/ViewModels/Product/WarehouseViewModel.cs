using System.ComponentModel.DataAnnotations;

namespace Boticario.BelezaWeb.Application.ViewModels.Product
{
	public class WarehouseViewModel
	{
		[Required(ErrorMessage = "Localidade do armazém é obrigatória")]
		[MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
		public string Locality { get; set; }

		[Required(ErrorMessage = "Quantidade é obrigatória")]
		[Range(0, int.MaxValue, ErrorMessage = "Quantidade informada inválida")]
		public int Quantity { get; set; }

		[Required(ErrorMessage = "Tipo armazem é obrigatório")]
		[MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
		public string Type { get; set; }
	}
}
