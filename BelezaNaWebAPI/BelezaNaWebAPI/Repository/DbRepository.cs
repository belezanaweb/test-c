using BelezaNaWebAPI.Models;
using Dapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BelezaNaWebAPI.Repository
{
    public class DbRepository
    {
        public Response Insert_Product(JsonModel value)
        {
            produto produtos = new produto();
            try
            {
                using (var sqlConnection = new SqlConnection(ConfigurationManager.
 ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    //Verifica se o produto a ser inserido já existe
                    produtos = sqlConnection.Query<produto>($@"SELECT TOP 1 * FROM [dbo].[produto] 
WHERE sku = '{value.sku}'").Single();
                }

                if (produtos != null && produtos != new produto())
                {
                    for (int i = 0; i < value.inventory.warehouses.Count(); i++)
                    {
                        using (var sqlConnection = new SqlConnection(ConfigurationManager.
ConnectionStrings["DefaultConnection"].ConnectionString))
                        {
                            var warehouse = sqlConnection.Query<warehouses>($@"SELECT * FROM 
                            [dbo].[warehouses] where locality='{value.inventory.warehouses[i].locality}' 
AND type = '{value.inventory.warehouses[i].type}'").Single();

                            if (warehouse != null)
                            {

                                sqlConnection.Execute($@"INSERT INTO [dbo].[produto] values ('{produtos.Id_inventory}','{value.name}','{value.sku}')");

                            }
                            else
                            {

                                sqlConnection.Execute($@"INSERT INTO [dbo].[warehouses] ([locality],[type]) values ('{value.inventory.warehouses[i].locality}','{value.inventory.warehouses[i].type}')");


                                var idWarehouse = sqlConnection.Query("SELECT CAST(SCOPE_IDENTITY() as int)");

                                sqlConnection.Execute($@"INSERT INTO [dbo].[inventory] ([Id_warehouse]) values ('{idWarehouse}')");

                                var idinventario = sqlConnection.Query("SELECT CAST(SCOPE_IDENTITY() as int)");

                                sqlConnection.Execute($@"INSERT INTO [dbo].[produto] ([Id_inventory],[name],[sku]) values ('{idinventario}','{value.name}','{value.sku}')");
                            }
                        }
                    }
                    using (var sqlConnection = new SqlConnection(ConfigurationManager.
ConnectionStrings["DefaultConnection"].ConnectionString))
                    {
                        var prod = sqlConnection.Query<produto>($@"SELECT * FROM [dbo].[produto] WHERE sku = '{value.sku}'").FirstOrDefault();
                        var inv = sqlConnection.Query<inventory>($@"SELECT * FROM [dbo].[inventory] WHERE Id = '{prod.Id_inventory}'").Single();
                        var wares = sqlConnection.Query<warehouses>($@"SELECT * FROM [dbo].[warehouses] as wa INNER JOIN [dbo].[inventory] inv 
ON wa.Id=inv.Id_warehouses WHERE inv.Id = '{prod.Id_inventory}'").Single();
                        if (prod != null)
                        {
                            produtos = prod;
                            produtos.inventory = inv;
                            produtos.inventory.warehouses = wares;
                        }
                    }
                    return new Response()
                    {
                        MessageResponse = JArray.Parse(JsonConvert.SerializeObject(produtos, Formatting.Indented)),
                        StatusMessage = $@"SKU Já existente - {value.sku} Produto adicionado no inventário!"
                    };

                }
                else
                {
                    for (int i = 0; i < value.inventory.warehouses.Count(); i++)
                    {
                        using (var sqlConnection = new SqlConnection(ConfigurationManager.
ConnectionStrings["DefaultConnection"].ConnectionString))
                        {
                            var warehouse = sqlConnection.Query<warehouses>($@"SELECT * FROM 
                            [dbo].[warehouses] where locality='{value.inventory.warehouses[i].locality}' 
AND type = '{value.inventory.warehouses[i].type}'").FirstOrDefault();

                            if (warehouse != null)
                            {
                                var inventario = sqlConnection.Query<inventory>($@"SELECT * FROM 
                            [dbo].[inventory] where Id_warehouses = '{warehouse.Id}'").FirstOrDefault();

                                if (inventario != null)
                                {
                                    sqlConnection.Execute($@"INSERT INTO [dbo].[produto] ([Id_inventory],[name],[sku]) 
values ('{inventario.Id}','{value.name}','{value.sku}')");
                                }
                                else
                                {
                                    sqlConnection.Execute($@"INSERT INTO [dbo].[inventory] values ('{warehouse.Id}')");

                                    var idInventario = sqlConnection.Execute("SELECT CAST(SCOPE_IDENTITY() as int)");

                                    sqlConnection.Execute($@"INSERT INTO [dbo].[produto] values ('{idInventario}','{value.name}','{value.sku}')");
                                }
                            }
                            else
                            {
                                sqlConnection.Execute($@"INSERT INTO [dbo].[warehouses] values ('{value.inventory.warehouses[i].locality}','{value.inventory.warehouses[i].type}')");

                                var idWarehouse = sqlConnection.Execute("SELECT CAST(SCOPE_IDENTITY() as int)");

                                sqlConnection.Execute($@"INSERT INTO [dbo].[inventory] ([Id_warehouse]) values ('{idWarehouse}')");

                                var idinventario = sqlConnection.Query("SELECT CAST(SCOPE_IDENTITY() as int)");

                                sqlConnection.Execute($@"INSERT INTO [dbo].[produto] ([Id_inventory],[name],[sku]) values ('{idinventario}','{value.name}','{value.sku}')");
                            }
                        }
                    }

                    return new Response()
                    {
                        MessageResponse = JArray.Parse(JsonConvert.SerializeObject(produtos, Formatting.Indented)),
                        StatusMessage = $@"Produto adicionado no inventário!"
                    };
                }

            }
            catch (Exception ex)
            {

                return new Response()
                {
                    StatusMessage = $@"Erro ao inserir o arquivo",
                    MessageError = ex.Message
                };
            }
        }


        public Response Update_Product(JsonModel value)
        {
            try
            {
                List<produto> produtos = new List<produto>();
                using (var sqlConnection = new SqlConnection(ConfigurationManager.
                ConnectionStrings["DefaultConnection"].ConnectionString))
                {

                    produtos = sqlConnection.Query<produto>($@"SELECT  * FROM [dbo].[produto] 
WHERE sku = '{value.sku}'").ToList();
                }

                if (produtos.Count() > 0)
                {
                    using (var sqlConnection = new SqlConnection(ConfigurationManager.
                ConnectionStrings["DefaultConnection"].ConnectionString))
                    {

                        sqlConnection.Execute($@"UPDATE [dbo].[produto] SET name = '{value.name}' WHERE sku = '{value.sku}'");

                    }
                    using (var sqlConnection = new SqlConnection(ConfigurationManager.
ConnectionStrings["DefaultConnection"].ConnectionString))
                    {
                        var prod = sqlConnection.Query<produto>($@"SELECT * FROM [dbo].[produto] WHERE sku = '{value.sku}'").ToList();
                        string inv_str = @"SELECT * FROM[dbo].[inventory] WHERE Id IN(";

                        for (int invstr = 0; invstr < prod.Count(); invstr++)
                        {
                            if (invstr+1 < prod.Count())
                            {
                                inv_str = inv_str + $@"'{prod[invstr].Id_inventory}',";
                            }
                            else
                            {
                                inv_str = inv_str + $@"'{prod[invstr].Id_inventory}')";
                            }

                        }


                        var inv = sqlConnection.Query<inventory>($@"{inv_str}").ToList();

                        string wares_str = @"SELECT * FROM[dbo].[warehouses] WHERE Id IN(";

                        for (int ware = 0; ware < inv.Count(); ware++)
                        {
                            if (ware+1 != inv.Count())
                            {
                                wares_str = wares_str + $@"'{inv[ware].Id_warehouses}',";
                            }
                            else
                            {
                                wares_str = wares_str + $@"'{inv[ware].Id_warehouses}')";
                            }
                        }
                        var wares = sqlConnection.Query<warehouses>($@"{wares_str}").ToList();
                        if (prod != null)
                        {

                            for (int p = 0; p < prod.Count(); p++)
                            {
                                produtos.Add(prod[p]);
                                for (int invc = 0; invc < inv.Count(); invc++)
                                {
                                    produtos[p].inventory = inv[invc];
                                    for (int warec = 0; warec < wares.Count(); warec++)
                                    {
                                        produtos[p].inventory.warehouses = wares[warec];
                                    }
                                }
                            }
                        }
                        else
                        {
                            return new Response()
                            {
                                MessageError = "Produto não existente, primeiro crie um produto realizando POST!",
                                StatusMessage = "Não Encontrado."
                            };
                        }
                    }
                    return new Response()
                    {
                        MessageResponse = JArray.Parse(JsonConvert.SerializeObject(produtos, Formatting.Indented)),
                        StatusMessage = $@"Produto atualizado!"
                    };
                }
                else
                {
                    return new Response()
                    {
                        MessageError = "Produto não existente, primeiro crie um produto realizando POST!",
                        StatusMessage = "Não Encontrado."
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    StatusMessage = $@"Erro ao atualizar o produto!",
                    MessageError = ex.Message
                };
            }

        }

        public Response Delete_Product(JsonModel value)
        {
            try
            {
                List<produto> produtos = new List<produto>();
                using (var sqlConnection = new SqlConnection(ConfigurationManager.
                ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    produtos = sqlConnection.Query<produto>($@"SELECT  * FROM [dbo].[produto] WHERE sku = '{value.sku}'").ToList();
                    int excluidos = 0;
                    if (produtos != null && produtos.Count() > 0)
                    {
                        for (int inv = 0; inv < produtos.Count(); inv++)
                        {
                            sqlConnection.Execute($@"DELETE FROM [dbo].[produto] where Id='{produtos[inv].Id}'");
                            excluidos++;
                        }
                    }
                    else
                    {
                        return new Response()
                        {
                            MessageError = "Produto não existente",
                            StatusMessage = "Não Encontrado."
                        };
                    }
                    return new Response()
                    {
                        MessageResponse = JArray.Parse($@"{excluidos} produtos excluídos."),
                        StatusMessage = $@"Produto excluido!"
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    StatusMessage = $@"Erro ao deletar o produto",
                    MessageError = ex.Message
                };
            }
        }

        public Response Get_Products()
        {
            try
            {
                List<produto> produtos = new List<produto>();
                using (var sqlConnection = new SqlConnection(ConfigurationManager.
                ConnectionStrings["DefaultConnection"].ConnectionString))
                {

                    produtos = sqlConnection.Query<produto>($@"SELECT  * FROM [dbo].[produto]").ToList();
                   
                    if(produtos.Count()>0)
                    {
                        for (int i = 0; i < produtos.Count(); i++)
                        {
                            produtos[i].inventory = sqlConnection.Query<inventory>($@"SELECT * FROM [dbo].[inventory] WHERE Id = '{produtos[i].Id_inventory}'").Single();
                            produtos[i].inventory.warehouses = sqlConnection.Query<warehouses>($@"SELECT * FROM [dbo].[warehouses] WHERE Id = '{produtos[i].inventory.Id_warehouses}'").Single();
                        }
                        return new Response()
                        {
                            MessageResponse = JArray.Parse(JsonConvert.SerializeObject(produtos, Formatting.Indented).ToString()),
                            StatusMessage = $@"Produtos retornados!"
                        };
                    }
                    else
                    {
                        return new Response()
                        {
                            MessageError=$@"Nenhum produto na base.",
                            StatusMessage = $@"Vazio"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    StatusMessage = $@"Erro ao retornar produtos",
                    MessageError = ex.Message
                };
            }
        }
    }
}