using SimpleStore.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStore.DataAccess.Data.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnityOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            AccountOwner = new AccountOwnerRepository(_dbContext);
        }

        public IAccountOwnerRepository AccountOwner { get; private set; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
