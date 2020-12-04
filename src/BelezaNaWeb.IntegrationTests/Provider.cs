using BelezaNaWeb.Data;
using BelezaNaWeb.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace BelezaNaWeb.IntegrationTests
{
    public class Provider : IDisposable
    {
        private TestServer server;
        public HttpClient Client { get; private set; }
        public BelezaNaWebDbContext Context;

        public Provider()
        {
            server = new TestServer(new WebHostBuilder()
                .ConfigureAppConfiguration((context, builder) => {
                    context.HostingEnvironment.EnvironmentName = "Test";
                    builder.AddJsonFile($"appsettings.Test.json", optional: false)
                        .AddEnvironmentVariables()
                        .Build();
                })
                .UseStartup<API.Startup>());

            Client = server.CreateClient();

            Context = server.Host.Services.GetService(typeof(BelezaNaWebDbContext)) as BelezaNaWebDbContext;

        }

        public void ClearTables()
        {
            Context.Products.RemoveRange(Context.Products.ToList());
            Context.Inventories.RemoveRange(Context.Inventories.ToList());
            Context.WareHouses.RemoveRange(Context.WareHouses.ToList());
            Context.SaveChanges();
        }

        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }

        internal void FixtureCreateTest()
        {
            var product = new Product()
            {
                Sku = 66666,
                Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                Inventory = new Inventory()
                {
                    WareHouses = new List<WareHouse>() {
                                                             new WareHouse() { Locality = "SP", Quantity = 12, Type = "ECOMMERCE" },
                                                             new WareHouse() { Locality = "MOEMA", Quantity = 3, Type = "PHYSICAL_STORE" }}
                }
            };

            Context.Products.Add(product);
            Context.SaveChanges();
        }
    }
}
