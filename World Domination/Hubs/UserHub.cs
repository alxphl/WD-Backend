using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WD.Entities;
using WD.Entities.DTO;
using WD.Interfaces;

namespace World_Domination.Hubs
{
    public class UserHub : Hub
    {
        readonly IUserRepository UserRepository;
        public UserHub(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        [HubMethodName("SignInUp")]
        public async Task<User> SignInUp(string PlayId)
        {

            var user = await UserRepository.GenerateJwt(PlayId);
            if (user != null)
            {
                Clients.Caller.SendAsync("UserFill", new UserDTO(user.Token,user.WinRate,user.LostRate,user.Losses,user.Wins,user.WorldDominationRank,user.Tear,user.Bank,user.Life,user.Strength)); return user;
            }
            else
            {
                var User = await UserRepository.CreateUser(PlayId);
                Clients.Caller.SendAsync("UserFill", new UserDTO(user.Token, user.WinRate, user.LostRate, user.Losses, user.Wins, user.WorldDominationRank, user.Tear, user.Bank, user.Life, user.Strength));
                return User;
            }
        }
    }
}

