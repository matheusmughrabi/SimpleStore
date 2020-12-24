using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Domain.UsersAccounts.AccountsModel;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SimpleStore.DataAccessLayer.Services.AccountsServices
{
    public class SqlServerAccountsService : BaseSqlServerService, IAccountsService
    {
        public SqlServerAccountsService(IConnection sqlServerConnection) : base(sqlServerConnection)
        {
        }

        public List<AccountModel> GetAccounts()
        {
            List<AccountModel> accounts = new List<AccountModel>();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spGetAccounts";

                _sqlServerConnection.OpenConnection();

                var sqlDataReader = _sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    AccountModel account;

                    while (sqlDataReader.Read())
                    {
                        account = new AccountModel(new UserModel());

                        account.Id = sqlDataReader.GetInt32(0);
                        account.User.Id = sqlDataReader.GetInt32(1);
                        account.User.FirstName = sqlDataReader.GetString(2);
                        account.User.LastName = sqlDataReader.GetString(3);
                        account.User.Username = sqlDataReader.GetString(4);
                        account.Balance = sqlDataReader.GetDecimal(5);

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

        public AccountModel GetAccountByUserId(int userId)
        {
            AccountModel account = new AccountModel(new UserModel());

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
                    account.User.Id = sqlDataReader.GetInt32(1);
                    account.User.FirstName = sqlDataReader.GetString(2);
                    account.User.LastName = sqlDataReader.GetString(3);
                    account.User.Username = sqlDataReader.GetString(4);
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

        public AccountModel UpdateAccountBalanceByUserId(AccountModel account)
        {
            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spUpdateAccountBalance";
                _sqlCommand.Parameters.AddWithValue("@UserId", account.User.Id);
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
