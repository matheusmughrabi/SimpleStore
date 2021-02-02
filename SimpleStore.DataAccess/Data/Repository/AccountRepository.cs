using SimpleStore.DataAccess.Data.Repository.IRepository;
using SimpleStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStore.DataAccess.Data.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void UpdateBalance(Account entity)
        {
            var objFromBd = GetById(entity.Id);

            objFromBd.Balance = entity.Balance;

            _dbContext.SaveChanges();
        }
    }
}
