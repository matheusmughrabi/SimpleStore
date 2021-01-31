using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Models.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SimpleStore.DataAccessLayer.Services.AccountsServices
{
    public class SqlServerAccountsService : BaseSqlServerService, IAccountsService
    {
        public SqlServerAccountsService(IConnection sqlServerConnection) : base(sqlServerConnection)
        {
        }

        public List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spGetAccounts";

                _sqlServerConnection.OpenConnection();

                var sqlDataReader = _sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    Account account;

                    while (sqlDataReader.Read())
                    {
                        account = new Account(new AccountOwner());

                        account.Id = sqlDataReader.GetInt32(0);
                        account.AccountOwner.Id = sqlDataReader.GetInt32(1);
                        account.AccountOwner.FirstName = sqlDataReader.GetString(2);
                        account.AccountOwner.LastName = sqlDataReader.GetString(3);
                        account.AccountOwner.Email = sqlDataReader.GetString(4);
                        account.AccountOwner.Username = sqlDataReader.GetString(5);
                        account.Balance = sqlDataReader.GetDecimal(6);

                        accounts.Add(account);
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
            return accounts;
        }

        public Account GetAccountByUserId(int userId)
        {
            Account account = new Account(new AccountOwner());

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spGetAccountByUserId";
                _sqlCommand.Parameters.AddWithValue("@UserId", userId);

                _sqlServerConnection.OpenConnection();

                var sqlDataReader = _sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();

                    account.Id = sqlDataReader.GetInt32(0);
                    account.AccountOwner.Id = sqlDataReader.GetInt32(1);
                    account.AccountOwner.FirstName = sqlDataReader.GetString(2);
                    account.AccountOwner.LastName = sqlDataReader.GetString(3);
                    account.AccountOwner.Username = sqlDataReader.GetString(4);
                    account.Balance = sqlDataReader.GetDecimal(5);
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

            return account;
        }

        public Account UpdateAccountBalanceByUserId(Account account)
        {
            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spUpdateAccountBalance";
                _sqlCommand.Parameters.AddWithValue("@UserId", account.AccountOwner.Id);
                _sqlCommand.Parameters.AddWithValue("@Balance", account.Balance);

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

            return account;
        }

        public bool CreateAccount(int UserId)
        {
            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spCreateAccount";

                _sqlCommand.Parameters.AddWithValue("UserId", UserId);
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
