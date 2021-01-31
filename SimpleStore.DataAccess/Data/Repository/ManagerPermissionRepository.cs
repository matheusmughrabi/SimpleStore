using SimpleStore.DataAccess.Data.Repository.IRepository;
using SimpleStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStore.DataAccess.Data.Repository
{
    public class ManagerPermissionRepository : Repository<ManagerPermission>, IManagerPermissionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ManagerPermissionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
