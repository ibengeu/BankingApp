using System;
using System.Linq;
using BankingAppTwo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankingAppTwo.Interfaces;

namespace BankingAppTwo.Services
{
    public class UserService
    {
        readonly BankContext _context;


        public UserService(BankContext context)
        {
            this._context = context;
        }



        public IEnumerable<User> GetAll()
        {

            return _context.User.Include("Account").ToList(); ;
        }

        public User Get(string bvn)
        {

            return _context.User.AsNoTracking().SingleOrDefault(user => user.BVN == bvn);

        }


        public async Task<ActionResult<User>> create(User user)
        {


            var userInDB = _context.User.Find(user.BVN);
            _context.Entry(userInDB).State = EntityState.Detached;


            if (userInDB is not null)
            {
                return userInDB;
            }

            _context.User.FromSqlInterpolated($"call public.create_user({user.UserId}, {user.FirstName}, {user.LastName}, {user.BVN},{user.Pin}, {user.createdAt}, {user.updatedAt},{user.BVN})");

            await _context.SaveChangesAsync();

            return user;
        }

        public void Write(string message)
        {
            throw new NotImplementedException();
        }
    }
}

