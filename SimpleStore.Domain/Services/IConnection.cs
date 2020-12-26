using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SimpleStore.Domain.Services
{
    public interface IConnection
    {
        void GetConnection();
        void OpenConnection();
        void CloseConnection();
    }
}
