using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using TesteProdutoSolange.Models;

namespace TesteProdutoSolange.Repository
{
    public class ProdutoRepository
    {
        string StringConnection = ConfigurationManager.ConnectionStrings["connectionStringName"].ConnectionString;

        public List<Produto> GetAll()
        {
            string sql = @"select * from Produto";

            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Produto> list = new List<Produto>();
                Produto p = null;                
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {                            
                            p.sku = (int)reader["sku"];
                            p.name = reader["name"].ToString();
                            p.isMarketable = (bool)reader["isMarketable"];
                            list.Add(p);

                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return list;
            }
        }
        public Produto GetById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = @"select * from Produto
                                where sku = @sku ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sku", id);

                Produto p = null;
                
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                p.sku = (int)reader["sku"];
                                p.name = reader["name"].ToString();
                                p.isMarketable = (bool)reader["isMarketable"];

                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return p;
            }
        }
        public void Save(Produto produto)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "insert into Produto values(sku, inventory = @inventory, isMarketable = @isMarketable)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@sku", produto.sku);
                cmd.Parameters.AddWithValue("@inventory", produto.inventory.Id);
                cmd.Parameters.AddWithValue("@isMarketable", produto.isMarketable);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }
        public void Delete(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "delete Produto where sku = @sku";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sku", id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public void Update(Produto produto)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "update Produto set sku = @sku, inventory = @inventory, isMarketable = @isMarketable where sku = @sku";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@sku", produto.sku);
                cmd.Parameters.AddWithValue("@inventory", produto.inventory.Id);
                cmd.Parameters.AddWithValue("@isMarketable", produto.isMarketable);              

               
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }

    }
}