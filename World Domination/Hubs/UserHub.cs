using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using WD.Entities;
using WD.Entities.DTO;
using WD.Interfaces;

namespace World_Domination.Hubs
{
    public class UserHub : Hub
    {
        readonly IUserRepository UserRepository;
        private readonly TokenConfiguration TokenConfiguration;
        public UserHub(IUserRepository userRepository, TokenConfiguration tokenConfiguration)
        {
            UserRepository = userRepository;
            TokenConfiguration = tokenConfiguration;
        }

        [HubMethodName("SignInUp")]
        public async Task<User> SignInUp(string PlayId)
        {

            var user = await UserRepository.GenerateJwt(PlayId);
            if (user != null)
            {
                user.Token=JwtAuthorization.GenerateToken(PlayId, TokenConfiguration);
                await Clients.Caller.SendAsync("UserFill", new UserDTO(user.Token,user.WinRate,user.LostRate,user.Losses,user.Wins,user.WorldDominationRank,user.Tear,user.Bank,user.Life,user.Strength)); return user;
            }
            else
            {
                var User = await UserRepository.CreateUser(PlayId);
                User.Token = JwtAuthorization.GenerateToken(PlayId, TokenConfiguration);
                await Clients.Caller.SendAsync("UserFill", new UserDTO(user.Token, user.WinRate, user.LostRate, user.Losses, user.Wins, user.WorldDominationRank, user.Tear, user.Bank, user.Life, user.Strength));
                return User;
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HubMethodName("BattleHandler")]
        public async Task<User> BattleHandler(BattleModeDTO battleModeDto)
        {
            var user = await UserRepository.BattleModeHandler(battleModeDto.PlayId, battleModeDto.BattleLife, battleModeDto.BattleStrength, battleModeDto.BattleMode, battleModeDto.Location);
            return user;

        }
    }
}

