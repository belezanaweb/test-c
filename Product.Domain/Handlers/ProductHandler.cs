using Flunt.Notifications;
using Product.Domain.Commands;
using Product.Domain.Commands.Contracts;
using Product.Domain.Entities;
using Product.Domain.Handlers.Contracts;
using Product.Domain.Repositories;


namespace Product.Domain.Handlers
{
    public class ProductHandler : Notifiable, IHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;

        public ProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateProductCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Os dados para a criação do produto estão inválidos", command.Notifications);

            var productExist = _repository.GetBySku(command.Sku);

            if(productExist != null && productExist.Id > 0)
                return new GenericCommandResult(false, "Dois produtos são considerados iguais se os seus skus forem iguais", command.Notifications);
           

            var product = new Entities.Product(command.Sku, command.Name, command.Inventory);

            _repository.Create(product);

            return new GenericCommandResult(true, "Produto salvo com sucesso", product);
        }

        public ICommandResult Handle(UpdateProductCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Os dados para a edição do produto estão inválidos", command.Notifications);

            var product = _repository.GetBySku(command.Sku);

            if (product == null || product.Sku == 0)
                return new GenericCommandResult(false, "Não foi encontrado nenhum produto para edição com o sku informado", command.Notifications);

            product.UpdateProduct(command.Name, command.Inventory);

            _repository.Update(product);

            return new GenericCommandResult(true, "Produto salvo com sucesso", product);
        }

        public ICommandResult Handle(DeleteProductCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Os dados para a exclusão do produto estão inválidos", command.Notifications);

            var product = _repository.GetBySku(command.Sku);

            if (product == null || product.Sku == 0)
                return new GenericCommandResult(false, "Não foi encontrado nenhum produto para exclusão com o sku informado", command.Notifications);

            _repository.Delete(product);

            return new GenericCommandResult(true, "Produto excluido com sucesso", product);
        }
    }
}
