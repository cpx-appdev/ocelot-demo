using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return UserRepository.Users.Values;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            if (UserRepository.Users.ContainsKey(id))
                return UserRepository.Users.GetValueOrDefault(id);
            else return "404";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var maxid = UserRepository.Users.Keys.Max();
            UserRepository.Users.Add(maxid + 1, value);
        } 

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            if (UserRepository.Users.ContainsKey(id))
                UserRepository.Users[id] = value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (UserRepository.Users.ContainsKey(id))
                UserRepository.Users.Remove(id);
        }
    }

    static class UserRepository
    {
        public static Dictionary<int, string> Users { get; private set; }
        
        static UserRepository()
        {
            Users = new Dictionary<int, string>
            {
                { 1, "User 1" },
                { 2, "User 2" },
                { 3, "User 3" }
            };
        }

        

    }
}
