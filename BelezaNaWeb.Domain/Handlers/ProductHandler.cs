using BelezaNaWeb.Domain.Commands;
using BelezaNaWeb.Domain.Commands.CreateProductCommand.Input;
using BelezaNaWeb.Domain.Commands.RemoveProductCommand.Input;
using BelezaNaWeb.Domain.Commands.UpdateProductCommand.Input;
using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Enums;
using BelezaNaWeb.Domain.Repositories;
using BelezaNaWeb.Shared.Commands;
using Flunt.Notifications;

namespace BelezaNaWeb.Domain.Handlers
{
    public class ProductHandler : Notifiable,
                                  ICommandHandler<CreateProductCommand>,
                                  ICommandHandler<UpdateProductCommand>,
                                  ICommandHandler<RemoveProductCommand> {

        private readonly IProductRepository productRepository;

        public ProductHandler(IProductRepository productRepository) {
            this.productRepository = productRepository;
        }

        public ICommandResult handle(CreateProductCommand command) {
            // Dois produtos são considerados iguais se os seus skus forem iguais
            if (productRepository.checkSkuExists(command.sku))
                AddNotification("sku", "Este SKU já está registrado");
            
            var inventory = new Inventory();
            foreach (var _warehouse in command.inventory.warehouses) {
                var warehouse = new Warehouse(_warehouse.locality, 
                                              _warehouse.quantity,
                                              _warehouse.type == "ECOMMERCE" ? WarehouseType.eCommerce : WarehouseType.physicalStore);
                inventory.add(warehouse);
            }

            var product = new Product(command.sku, command.name, inventory);
            command.valid();
            AddNotifications(command.Notifications);
        
            if (!Invalid) {
                this.productRepository.save(product);
                return new CommandResult(true, "Produto Regitrado com êxito", command); 
            } else
                return new CommandResult(false, "Por favor, corrija os campos abaixo", this.Notifications);

        }

        public ICommandResult handle(UpdateProductCommand command) {
            var inventory = new Inventory();
            foreach (var _warehouse in command.inventory.warehouses) {
                var warehouse = new Warehouse(_warehouse.locality,
                                              _warehouse.quantity,
                                              _warehouse.type == "ECOMMERCE" ? WarehouseType.eCommerce : WarehouseType.physicalStore);
                inventory.add(warehouse);
            }

            var product = new Product(command.sku, command.name, inventory);
            command.valid();
            AddNotifications(command.Notifications);
            
            if (!Invalid) {
                this.productRepository.update(product);
                return new CommandResult(true, "Produto Regitrado com êxito", command);
            } else
                return new CommandResult(false, "Por favor, corrija os campos abaixo", this.Notifications);

        }

        public ICommandResult handle(RemoveProductCommand command) {
            AddNotifications(command.Notifications);

            if (this.Invalid)
                return new CommandResult(false, "Por favor, corrija os campos abaixo", this.Notifications);

            var deleted = this.productRepository.delete(command.sku);
            return deleted ? new CommandResult(true, "Produto removido com êxito", command) : new CommandResult(false, "sku não encontrada", command);
        }
    }
}
