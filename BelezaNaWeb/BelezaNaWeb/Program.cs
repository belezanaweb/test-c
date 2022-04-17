using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Constants;
using BelezaNaWeb.Repository;
using BelezaNaWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#region Mock

    var productRepository = new ProductRepository();
    var warehouse1 = new Warehouse { Locality = "SP", Quantity = 10, Type = WareHouseTypeConstants.ECOMMERCE };
    var warehouse2 = new Warehouse { Locality = "RJ", Quantity = 12, Type = WareHouseTypeConstants.ECOMMERCE };
    var warehouse3 = new Warehouse { Locality = "RJ", Quantity = 0, Type = WareHouseTypeConstants.PHYSICAL_STORE };
    var warehouse4 = new Warehouse { Locality = "MOEMA", Quantity = 0, Type = WareHouseTypeConstants.ECOMMERCE };

    productRepository.Create(new Product(new Inventory(new List<Warehouse> { warehouse1, warehouse2 })) { Name = "prod1", Sku = 123 });
    productRepository.Create(new Product(new Inventory(new List<Warehouse> { warehouse3, warehouse4 })) { Name = "prod2", Sku = 321 });
    productRepository.Create(new Product(new Inventory(new List<Warehouse> { warehouse1, warehouse2, warehouse3 })) { Name = "prod3", Sku = 444 });

#endregion


app.Run();