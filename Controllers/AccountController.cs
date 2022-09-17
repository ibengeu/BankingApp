using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingAppTwo.DTOs;
using BankingAppTwo.Models;
using BankingAppTwo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingAppTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        // GET: api/Account
        readonly AccountService _service;

        public AccountController(AccountService service)
        {
            _service = service;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<Account> GetAll()
        {


            return _service.GetAll();
        }

        // GET: api/Account/5
        [HttpGet("{accountNumber}")]
        public static Account Get(string accountNumber)
        {


            return null;
        }

        // POST: api/Account
        [HttpPost]
        public async Task<ActionResult<Account>> Post([FromBody] UserDTO details)
        {

            DateTime dt = DateTime.Now;
            DateTime ut = DateTime.SpecifyKind(dt, DateTimeKind.Utc);
            Guid guid = new();

            User user = new()
            {
                UserId = guid,
                FirstName = details.FirstName,
                LastName = details.LastName,
                Pin = details.Pin,
                BVN = details.BVN,
                Email = details.Email,
                updatedAt = ut,
                createdAt = ut


            };


            //var server = await _service.create(user);

            //if(server is not null)
            //{
            //    return BadRequest("User exists, Please create a new account");
            //}

            return null;
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
