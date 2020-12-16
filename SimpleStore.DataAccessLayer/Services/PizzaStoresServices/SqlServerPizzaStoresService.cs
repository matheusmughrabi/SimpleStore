using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.IPizzaStoreServices;
using SimpleStore.Domain.Stores.Models.PizzaStores;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SimpleStore.DataAccessLayer.Services.PizzaStoreServices
{
    public class SqlServerPizzaStoresService : BaseSqlServerService, IPizzaStoresService
    {
        public SqlServerPizzaStoresService(IConnection sqlServerConnection) : base(sqlServerConnection)
        {
        }

        public List<IPizzaStore> GetPizzaStores()
        {
            List<IPizzaStore> pizzaStores = new List<IPizzaStore>();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spGetPizzaStores";

                _sqlServerConnection.OpenConnection();

                var sqlDataReader = _sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    IPizzaStore pizzaStore;

                    while (sqlDataReader.Read())
                    {
                        pizzaStore = new PizzaStoreModel();

                        pizzaStore.Id = sqlDataReader.GetInt32(0);
                        pizzaStore.StoreName = sqlDataReader.GetString(1);

                        pizzaStores.Add(pizzaStore);
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

            return pizzaStores;
        }
    }
}
