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
    public class UserController : ControllerBase
    {
        readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {


            return _service.GetAll();
        }

        // GET: api/User/5
        [HttpGet("{bvn}", Name = "Get")]
        public User Get(string bvn)
        {


            return _service.Get(bvn);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] UserDTO details)
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


            var server = await _service.create(user);

            if(server is not null)
            {
                return BadRequest("User exists, Please create a new account");
            }

            return server;
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
