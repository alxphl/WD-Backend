using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WD.Entities;
using WD.Entities.DTO;
using WD.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace World_Domination
{

    public class BattleHub: Hub
    {
        readonly IUserRepository UserRepository;
        public BattleHub(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public void SendToChannel(string name, string message)
        {
            Clients.All.SendAsync("SendToChannel", name, message);
        }

        [HubMethodName("BattleHandler")]
        public async Task<User> BattleHandler(BattleModeDTO battleModeDto)
        {
            var user= await UserRepository.BattleModeHandler(battleModeDto.PlayId, battleModeDto.BattleLife, battleModeDto.BattleStrength, battleModeDto.BattleMode, battleModeDto.Location);
            return user;

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HubMethodName("BattleHandler2")]
        public async Task<User> BattleHandler2(BattleModeDTO battleModeDto)
        {
            var user = await UserRepository.BattleModeHandler(battleModeDto.PlayId, battleModeDto.BattleLife, battleModeDto.BattleStrength, battleModeDto.BattleMode, battleModeDto.Location);
            return user;

        }


    }
}
