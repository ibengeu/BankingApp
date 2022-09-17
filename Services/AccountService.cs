using System;
using BankingAppTwo.Models;

namespace BankingAppTwo.Services
{
    public class AccountService
    {
        readonly BankContext _context;

        public AccountService(BankContext bankContext)
        {
            _context = bankContext;
        }


        public IEnumerable<Account> GetAll()
        {

            return _context.Account.ToList(); ;
        }
    }
}

