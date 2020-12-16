using SimpleStore.Domain.Products.Models.Pizzas;
using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.PizzasServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SimpleStore.DataAccessLayer.Services.PizzasServices
{
    public class SqlServerPizzasService : BaseSqlServerService, IPizzasService
    {
        public SqlServerPizzasService(IConnection sqlServerConnection) : base(sqlServerConnection)
        {
        }

        public List<IPizza> GetPizzas(int pizzaStoreId)
        {
            List<IPizza> pizzas = new List<IPizza>();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spGetPizzaStorePizzas";
                _sqlCommand.Parameters.AddWithValue("@PizzaStoreId", pizzaStoreId);

                _sqlServerConnection.OpenConnection();

                var sqlDataReader = _sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    IPizza pizza;

                    while (sqlDataReader.Read())
                    {
                        pizza = new PizzaModel();

                        pizza.Id = sqlDataReader.GetInt32(0);                      
                        pizza.Type = sqlDataReader.GetString(1);
                        pizza.Sauce = sqlDataReader.GetString(2);
                        pizza.Price = sqlDataReader.GetDecimal(3);

                        pizzas.Add(pizza);
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
            return pizzas;
        }
    }
}