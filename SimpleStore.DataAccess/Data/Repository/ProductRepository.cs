﻿using SimpleStore.DataAccess.Data.Repository.IRepository;
using SimpleStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStore.DataAccess.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void UpdateQuantityInStock(Product entity)
        {
            var objFromDb = GetById(entity.Id);

            objFromDb.QuantityInStock = entity.QuantityInStock;
            _dbContext.SaveChanges();
        }
    }
}
