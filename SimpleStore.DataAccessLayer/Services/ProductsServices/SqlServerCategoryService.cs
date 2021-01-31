using SimpleStore.DataAccessLayer.Helpers;
using SimpleStore.Domain.Products;
using SimpleStore.Models.Models;
using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.ProductsServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SimpleStore.DataAccessLayer.Services.ProductsServices
{
    public class SqlServerCategoryService : BaseSqlServerService, ICategoryService
    {
        public SqlServerCategoryService(IConnection sqlServerConnection) : base(sqlServerConnection)
        {
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spGetCategories";

                _sqlServerConnection.OpenConnection();

                var sqlDataReader = _sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    Category category;

                    while (sqlDataReader.Read())
                    {
                        category = new Category();

                        category.Id = sqlDataReader.GetInt32(0);
                        category.Name = sqlDataReader.GetString(1);
                        category.ParentCategoryId = sqlDataReader.SafeGetInt(2);
                        category.InsertedAt = sqlDataReader.GetDateTime(3);
                        category.UpdatedAt = sqlDataReader.SafeGetDateTime(4);

                        categories.Add(category);
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
            return categories;
        }

        public Category GetCategoryByName(string categoryName)
        {
            Category category = new Category();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spGetCategoryByName";
                _sqlCommand.Parameters.AddWithValue("@Category", categoryName);

                _sqlServerConnection.OpenConnection();

                var sqlDataReader = _sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();

                    category.Id = sqlDataReader.GetInt32(0);
                    category.Name = sqlDataReader.GetString(1);
                    category.ParentCategoryId = sqlDataReader.SafeGetInt(2);
                    category.InsertedAt = sqlDataReader.GetDateTime(3);
                    category.UpdatedAt = sqlDataReader.SafeGetDateTime(4);
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
            return category;
        }

        public Category InsertCategory(Category category)
        {
            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spInsertCategory";

                _sqlCommand.Parameters.AddWithValue("@Category", category.Name);
                if (category.ParentCategoryId == null)
                {
                    _sqlCommand.Parameters.AddWithValue("@ParentId", DBNull.Value);
                }
                else
                {
                    _sqlCommand.Parameters.AddWithValue("@ParentId", category.ParentCategoryId);
                }
                _sqlCommand.Parameters.AddWithValue("@InsertedAt", DateTime.Now);
                _sqlCommand.Parameters.AddWithValue("@UpdatedAt", DBNull.Value);
                _sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                _sqlServerConnection.OpenConnection();
                _sqlCommand.ExecuteNonQuery();

                category.Id = Convert.ToInt32(_sqlCommand.Parameters["@Id"].Value);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                _sqlServerConnection.CloseConnection();
            }

            return category;
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spDeleteCategory";

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
