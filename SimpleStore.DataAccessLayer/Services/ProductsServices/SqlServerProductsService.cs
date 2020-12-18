using SimpleStore.DataAccessLayer.Helpers;
using SimpleStore.Domain.Products.Categories;
using SimpleStore.Domain.Products.ProductsModel;
using SimpleStore.Domain.Products.ProductStatuses;
using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.ProductsServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SimpleStore.DataAccessLayer.Services.ProductsServices
{
    public class SqlServerProductsService : BaseSqlServerService, IProductsService
    {
        public SqlServerProductsService(IConnection sqlServerConnection) : base(sqlServerConnection)
        {
        }

        public List<ProductModel> GetProducts()
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
                        product.Category = new CategoryModel();
                        product.ProductStatus = new ProductStatusModel();

                        product.Id = sqlDataReader.GetInt32(0);
                        product.Name = sqlDataReader.GetString(1);
                        product.Brand = sqlDataReader.GetString(1);
                        product.Category.Id = sqlDataReader.GetInt32(3);
                        product.RegularPrice = sqlDataReader.GetDecimal(4);
                        product.DiscountedPrice = sqlDataReader.GetDecimal(5);
                        product.Description = sqlDataReader.GetString(6);
                        product.ProductStatus.Id = sqlDataReader.GetInt32(7);
                        product.InsertedAt = sqlDataReader.GetDateTime(8);
                        product.UpdatedAt = sqlDataReader.SafeGetDateTime(9);

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
            return products;
        }

        public List<ProductModel> GetProductsByCategory(int categoryId)
        {
            List<ProductModel> products = new List<ProductModel>();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spGetProductsByCategory";
                _sqlCommand.Parameters.AddWithValue("@CategoryId", categoryId);

                _sqlServerConnection.OpenConnection();

                var sqlDataReader = _sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    ProductModel product;

                    while (sqlDataReader.Read())
                    {
                        product = new ProductModel();
                        product.Category = new CategoryModel();
                        product.ProductStatus = new ProductStatusModel();

                        product.Id = sqlDataReader.GetInt32(0);
                        product.Name = sqlDataReader.GetString(1);
                        product.Brand = sqlDataReader.GetString(1);
                        product.Category.Id = sqlDataReader.GetInt32(3);
                        product.RegularPrice = sqlDataReader.GetDecimal(4);
                        product.DiscountedPrice = sqlDataReader.GetDecimal(5);
                        product.Description = sqlDataReader.GetString(6);
                        product.ProductStatus.Id = sqlDataReader.GetInt32(7);
                        product.InsertedAt = sqlDataReader.GetDateTime(8);
                        product.UpdatedAt = sqlDataReader.SafeGetDateTime(9);

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
            return products;
        }
    }
}
