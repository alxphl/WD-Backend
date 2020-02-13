﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WD.Entities;
using WD.Entities.DTO;
using WD.Interfaces;

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
        public async Task<User> BattleHandler(string playId, int battleLife, int battleStrength)
        {
            BattleModeDTO battleModeDto = new BattleModeDTO();

            var user= await UserRepository.BattleModeHandler(battleModeDto.PlayId, battleModeDto.BattleLife, battleModeDto.BattleStrength, battleModeDto.BattleMode, battleModeDto.Location);
            return user;

        }


    }
}
