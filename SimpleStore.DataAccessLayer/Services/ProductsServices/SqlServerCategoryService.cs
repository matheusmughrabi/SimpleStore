using SimpleStore.DataAccessLayer.Helpers;
using SimpleStore.Domain.Products.Categories;
using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.ProductsServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SimpleStore.DataAccessLayer.Services.ProductsServices
{
    public class SqlServerCategoryService : BaseSqlServerService, ICategoryService
    {
        public SqlServerCategoryService(IConnection sqlServerConnection) : base(sqlServerConnection)
        {
        }

        public List<CategoryModel> GetCategories()
        {
            List<CategoryModel> categories = new List<CategoryModel>();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spGetCategories";

                _sqlServerConnection.OpenConnection();

                var sqlDataReader = _sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    CategoryModel category;

                    while (sqlDataReader.Read())
                    {
                        category = new CategoryModel();

                        category.Id = sqlDataReader.GetInt32(0);
                        category.CategoryName = sqlDataReader.GetString(1);
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

        public CategoryModel InsertCategory(CategoryModel category)
        {
            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spInsertCategory";

                _sqlCommand.Parameters.AddWithValue("@Category", category.CategoryName);
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
    }
}
