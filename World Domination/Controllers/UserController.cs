using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WD.Entities;
using WD.Entities.DTO;
using WD.Interfaces;

namespace WD.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserRepository UserRepository;

        public UserController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("{PlayId}")]
        public async Task<User> SignInUp(string PlayId)
        {
            var user=await UserRepository.GetByPlayIdSync(PlayId);
            if (user!= null) return user;
            else
            {
                var User = await UserRepository.CreateUser(PlayId);

                return User;
            }
        }
           

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignDTO signUpDto) =>
            Ok(await UserRepository.CreateUser(signUpDto.PlayId));
    }
}
