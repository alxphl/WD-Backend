using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WD.Entities.DTO;
using WD.Interfaces;

namespace WD.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleController : ControllerBase
    {
        readonly IUserRepository UserRepository;

        public BattleController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        // GET: api/Battle
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Battle/5
        [HttpGet("{id}", Name = "GetBAttle")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Battle
        [HttpPost("BattleMode")]
        public void Post([FromBody] BattleModeDTO battleModeDto)=>
            UserRepository.BattleModeHandler(battleModeDto.PlayId, battleModeDto.BattleLife, battleModeDto.BattleStrength, battleModeDto.BattleMode,battleModeDto.Location);

        // PUT: api/Battle/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
