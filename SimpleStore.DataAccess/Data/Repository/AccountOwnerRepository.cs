using Microsoft.EntityFrameworkCore;
using SimpleStore.DataAccess.Data.Repository.IRepository;
using SimpleStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStore.DataAccess.Data.Repository
{
    public class AccountOwnerRepository : Repository<AccountOwner>, IAccountOwnerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountOwnerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void UpdateRole(AccountOwner accountOwner)
        {
            var objFromDb = GetById(accountOwner.Id);

            objFromDb.RoleId = accountOwner.RoleId;

            _dbContext.SaveChanges();
        }
    }
}
