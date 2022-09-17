using System;
using System.Configuration;
using BankingAppTwo.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingAppTwo.Services
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> dbContext) : base(dbContext)
        {

        }



        public DbSet<User> User => Set<User>();
        public DbSet<Account> Account => Set<Account>();


    }
}

