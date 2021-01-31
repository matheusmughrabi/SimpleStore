using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStore.DataAccess.Data.Repository.IRepository
{
    public interface IUnityOfWork : IDisposable
    {
        void Save();

        public IAccountOwnerRepository AccountOwner { get; }
        public IAccountRepository Account { get; }
    }
}
