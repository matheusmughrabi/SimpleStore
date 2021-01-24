using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.IRepository
{
    public interface IRepositorySPCall : IDisposable
    {
        T ExecuteReturnScaler<T>(string procedureName, DynamicParameters param = null);

        void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null);

        IEnumerable<T> ExecuteReturnList<T>(string procedureName, DynamicParameters param = null);
    }
}
