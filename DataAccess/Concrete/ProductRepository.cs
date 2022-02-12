using System.Collections.Generic;
using System.Data;
using CoreConvertingTools;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;
using Oracle.ManagedDataAccess.Client;

namespace DataAccess.Concrete
{
    public class ProductRepository:IProductRepository
    {
        public string OracleConnectionString = OracleContext.ConnectionString;

        public List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();

            using OracleConnection oracleConnection = new OracleConnection(OracleConnectionString);
            oracleConnection.Open();

            using OracleCommand cmd = oracleConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM PRODUCTS";

            var reader = cmd.ExecuteReader();

            if (!reader.HasRows) return list;

            while (reader.Read())
            {
                list.Add(new Product()
                {
                    ProductId = reader["PRODUCTID"].ToInt(),
                    ProductName = reader["PRODUCTNAME"].ToString(),
                    Price = reader["PRICE"].ToDouble()
                });
            }

            oracleConnection.Close();

            return list;
        }

        public void AddProduct(Product product)
        {
            using OracleConnection oracleConnection = new OracleConnection(OracleConnectionString);
            oracleConnection.Open();

            OracleCommand command = oracleConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_PRODUCT_INSERT";
            command.Parameters.Add("P_PRODUCTNAME", OracleDbType.Varchar2).Value = product.ProductName;
            command.Parameters.Add("P_PRICE", OracleDbType.Double).Value = product.Price;
            command.ExecuteNonQuery();
            oracleConnection.Close();
        }
    }
}