namespace Boticario.BelezaWeb.Domain.Catalog.Messages
{
	public class ProductMessages
	{
		public const string SuccessRegister = "Cadastro efetuado com sucesso.";
		public const string SuccessEdit = "Cadastro alterado com sucesso.";
		public const string SuccessDelete = "Cadastro removido com sucesso.";
		public const string NotFound = "Produto não encontrado.";

		public const string ErrorSkuExisting = "Sku já existente.";
		public const string ErrorSkuWasntProvided = "Sku é obrigatório.";
		public const string ErrorNameWasntProvided = "Nome é obrigatório.";
		public const string ErrorInventoryWasntProvided = "Dados estoque são obrigatórios.";
		public const string ErrorWharehouseWasntProvided = "Dados armazém são obrigatórios.";
		public const string ErrorWharehouseLocalityWasntProvided = "Localidade do armazém é obrigatória.";
		public const string ErrorWharehouseQuantityWasntProvided = "Quantidade é obrigatória.";
		public const string ErrorWharehouseTypeWasntProvided = "Tipo armazem é obrigatório.";
	}
}
