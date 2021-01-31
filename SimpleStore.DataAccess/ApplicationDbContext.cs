using Microsoft.EntityFrameworkCore;
using SimpleStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESSNOVA;Database=extfactory;Trusted_Connection=True;");
        }

        public DbSet<AccountOwner> AccountOwner { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ManagerAccount> Manager { get; set; }
        public DbSet<ManagerPermission> ManagerPermission { get; set; }
    }
}
