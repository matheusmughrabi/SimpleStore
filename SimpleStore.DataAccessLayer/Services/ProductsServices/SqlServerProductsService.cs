using SimpleStore.DataAccessLayer.Helpers;
using SimpleStore.Domain.Products;
using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.ProductsServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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

                        product.Id = sqlDataReader.GetInt32(0);
                        product.Name = sqlDataReader.GetString(1);
                        product.Brand = sqlDataReader.GetString(2);
                        product.Category.Id = sqlDataReader.GetInt32(3);
                        product.RegularPrice = sqlDataReader.GetDecimal(4);
                        product.DiscountedPrice = sqlDataReader.GetDecimal(5);
                        product.Description = sqlDataReader.GetString(6);
                        product.QuantityInStock = sqlDataReader.GetInt32(7);
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

        public ProductModel GetProductsByName(string name)
        {
            ProductModel product = new ProductModel();
            product.Category = new CategoryModel();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spGetProductByName";
                _sqlCommand.Parameters.AddWithValue("@Name", name);

                _sqlServerConnection.OpenConnection();

                var sqlDataReader = _sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();

                    product.Id = sqlDataReader.GetInt32(0);
                    product.Name = sqlDataReader.GetString(1);
                    product.Brand = sqlDataReader.GetString(2);
                    product.Category.Id = sqlDataReader.GetInt32(3);
                    product.RegularPrice = sqlDataReader.GetDecimal(4);
                    product.DiscountedPrice = sqlDataReader.GetDecimal(5);
                    product.Description = sqlDataReader.GetString(6);
                    product.QuantityInStock = sqlDataReader.GetInt32(7);
                    product.InsertedAt = sqlDataReader.GetDateTime(8);
                    product.UpdatedAt = sqlDataReader.SafeGetDateTime(9);
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

                        product.Id = sqlDataReader.GetInt32(0);
                        product.Name = sqlDataReader.GetString(1);
                        product.Brand = sqlDataReader.GetString(2);
                        product.Category.Id = sqlDataReader.GetInt32(3);
                        product.RegularPrice = sqlDataReader.GetDecimal(4);
                        product.DiscountedPrice = sqlDataReader.GetDecimal(5);
                        product.Description = sqlDataReader.GetString(6);
                        product.QuantityInStock = sqlDataReader.GetInt32(7);
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

        public ProductModel InsertProduct(ProductModel product)
        {
            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spInsertProduct";

                _sqlCommand.Parameters.AddWithValue("@Name", product.Name);
                _sqlCommand.Parameters.AddWithValue("@Brand", product.Brand);
                _sqlCommand.Parameters.AddWithValue("@CategoryId", product.Category.Id);
                _sqlCommand.Parameters.AddWithValue("@RegularPrice", product.RegularPrice);
                _sqlCommand.Parameters.AddWithValue("@DiscountedPrice", product.DiscountedPrice);
                _sqlCommand.Parameters.AddWithValue("@Description", product.Description);
                _sqlCommand.Parameters.AddWithValue("@QuantityInStock", product.QuantityInStock);
                _sqlCommand.Parameters.AddWithValue("@InsertedAt", DateTime.Now);
                _sqlCommand.Parameters.AddWithValue("@UpdatedAt", DBNull.Value);
                _sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                _sqlServerConnection.OpenConnection();
                _sqlCommand.ExecuteNonQuery();

                product.Id = Convert.ToInt32(_sqlCommand.Parameters["@Id"].Value);

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

        public bool UpdateProductQuantityInStock(int id, int quantity)
        {
            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spUpdateProductQuantityInStock";

                _sqlCommand.Parameters.AddWithValue("@Id", id);
                _sqlCommand.Parameters.AddWithValue("@QuantityInStock", quantity);
                _sqlCommand.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);

                _sqlServerConnection.OpenConnection();
                _sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                _sqlServerConnection.CloseConnection();
            }

            return true;
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spDeleteProduct";

                _sqlCommand.Parameters.AddWithValue("@Id", id);

                _sqlServerConnection.OpenConnection();
                _sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                _sqlServerConnection.CloseConnection();
            }

            return true;
        }
    }
}
