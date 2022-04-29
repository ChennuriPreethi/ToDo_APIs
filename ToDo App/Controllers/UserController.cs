using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo_App.Context;
using ToDo_App.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDo_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _UserContext;

        public UserController(UserContext UserContext)
        {
            _UserContext = UserContext;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _UserContext.Users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return _UserContext.Users.SingleOrDefault(x => x.UserId == id);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _UserContext.Users.Add(user);
            _UserContext.SaveChanges();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            user.UserId = id;
            _UserContext.Users.Update(user);
            _UserContext.SaveChanges();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _UserContext.Users.FirstOrDefault(x => x.UserId == id);
            if (item != null)
            {
                _UserContext.Users.Remove(item);
                _UserContext.SaveChanges();
            }
        }
    }
}
