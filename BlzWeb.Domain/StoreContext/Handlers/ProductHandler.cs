using BlzWeb.Domain.StoreContext.CustomerCommands.Inputs;
using BlzWeb.Domain.StoreContext.Entities;
using BlzWeb.Domain.StoreContext.Enums;
using BlzWeb.Domain.StoreContext.Repositories;
using BlzWeb.Shared.Commands;
using FluentValidator;
using System;
using System.Linq;

namespace BlzWeb.Domain.StoreContext.Handlers
{
    public class ProductHandler :
        Notifiable,
        ICommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;
       

        public ProductHandler(IProductRepository repository)
        {
            _repository = repository;
           
        }

        public ICommandResult Handle(CreateProductCommand command)
        {
          
            if (_repository.CheckSku(command.Sku))
                AddNotification("Sku", "Este produto já está cadastrado");
                                    
            // Criar os VOs
            var inventory = new Inventory(0);
            foreach (var item in command.Warehouses)
            {
                var warehouse = new Warehouse(item.Locality,item.Quantity, (EWarehouseType)Enum.Parse(typeof(EWarehouseType), item.Type, true));
                inventory.AddWarehouse(warehouse);
            }
            // Criar a entidade
            var product = new Product(command.Sku,command.Name,inventory);
            
            product.CalculateInventory();

            product.ChangeIsMarketable();

            // Validar entidades e VOs
            AddNotifications(inventory,product);
         
            if (Invalid)
                return new CommandResult(
                    false,
                    "Atenção! Não foi possível cadastrar o produto:",
                    Notifications);

            // Persistir o produto
            _repository.Save(product);

            // Retornar o resultado para tela
            return new CommandResult(true, "Produto cadastrado", new
            {
                Sku = product.Sku,
                Name = product.ToString()
            });
        }

        public CommandResult Delete(int sku)
        {
            _repository.Delete(sku);
            // Retornar o resultado para tela
            return new CommandResult(true, "Produto Excluiído", new
            {
                Sku = sku
            });
        }

        public ICommandResult Handle(UpdateProductCommand command)
        {
            // Toda vez que um produto for recuperado por sku deverá ser calculado a propriedade: inventory.quantity
            // A propriedade inventory.quantity é a soma da quantity dos warehouses
            var product = _repository.Get(command.Sku);
            product.CalculateInventory();

            // Toda vez que um produto for recuperado por sku deverá ser calculado a propriedade: isMarketable
            //Um produto é marketable sempre que seu inventory.quantity for maior que 0
            product.ChangeIsMarketable();


            //Ao atualizar um produto, o antigo deve ser sobrescrito com o que esta sendo enviado na requisição
            //A requisição deve receber o sku e atualizar com o produto que tbm esta vindo na requisição

            // Atualizar a entidade
            product = new Product(product.Sku, command.Name,  product.Inventory);


            if (Invalid)
                return new CommandResult(
                    false,
                    "Atenção! Não foi possível atualizar o produto:",
                    Notifications);

            // Atualizar o produto
            _repository.Update(product);

            // Retornar o resultado para tela
            return new CommandResult(true, "Produto atualizado", new
            {
                Sku = product.Sku,
                Name = product.ToString()
            });
        }
    }
}
