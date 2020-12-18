using SimpleStore.Domain.Products.ProductsModel;
using SimpleStore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SimpleStore.DataAccessLayer.Services.ProductsServices
{
    public class SqlServerProductsServices : BaseSqlServerService
    {
        public SqlServerProductsServices(IConnection sqlServerConnection) : base(sqlServerConnection)
        {
        }

        public List<ProductModel> GetProducts(int pizzaStoreId)
        {
            List<ProductModel> products = new List<ProductModel>();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spGetProducts";

                _sqlServerConnection.OpenConnection();

                var sqlDataReader = _sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    ProductModel product;

                    while (sqlDataReader.Read())
                    {
                        product = new ProductModel();

                        product.Id = sqlDataReader.GetInt32(0);
                        product.Name = sqlDataReader.GetString(1);
                        product.Category.Id = sqlDataReader.GetInt32(2);
                        product.RegularPrice = sqlDataReader.GetDecimal(3);
                        product.DiscountedPrice = sqlDataReader.GetDecimal(4);
                        product.Description = sqlDataReader.GetString(5);
                        product.ProductStatusId.Id = sqlDataReader.GetInt32(6);
                        product.InsertedAt = sqlDataReader.GetDateTime(7);
                        product.UpdatedAt = sqlDataReader.GetDateTime(8);

                        products.Add(product);
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                _sqlServerConnection.CloseConnection();
            }
            return product;
        }
    }
}
