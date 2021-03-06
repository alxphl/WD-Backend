﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WD.Entities;
using WD.Interfaces;

namespace WD.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MongoContext _context;
        private readonly ISecurityService SecurityService;
        public UserRepository(IOptions<DBSettings> settings, ISecurityService securityService)
        {
            _context=new MongoContext(settings);
            SecurityService = securityService;
        }
        public async Task<bool> IsExists(Expression<Func<User, bool>> expr) =>
            await _context.Users.CountDocumentsAsync(expr) > 0;

        public async Task<User> GetByPlayIdSync(string userId)
        {
           var Users= await GetUsers(x => x.PlayId!=null);
          var user= Users.Where(x => x.PlayId == userId).FirstOrDefault();
          return user;

        }
        public async Task<User> GenerateJwt(string userId)
        {
            
            var user =await GetByPlayIdSync(userId);
            if (user != null)
            {

             // user=SecurityService.GenerateJWT(user);
             // await UpdateToken(user);
              return user;
            }

            return null;

        }

        public async Task<User> UpdateToken(User user)
        {
            await _context.Users.ReplaceOneAsync(x => x.PlayId == user.PlayId, user);
            return user;
        }
        public async Task<User> BattleModeHandler(string PlayId, int battleLife, int battleStrength, bool BattleMode, LocationCoords location)
        {
            var Users = await GetUsers(x => x.PlayId != null);
            var user = Users.Where(x => x.PlayId == PlayId).FirstOrDefault();
            if (user != null)
            {
                if (BattleMode == true)
                {
                    if (user.Life - battleLife >= 0 && user.Strength - battleStrength >= 0)
                    {
                        user.BattleMode = true;
                        user.BattleLife = battleLife;
                        user.Life = user.Life - battleLife;
                        user.BattleStrength = battleStrength;
                        user.Strength = user.Strength - battleStrength;
                        user.Location = location;
                        await _context.Users.FindOneAndReplaceAsync(x => x.PlayId == PlayId, user);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    user.BattleMode = false;
                    user.Life = user.Life + user.BattleLife;
                    user.BattleLife = 0;
                    user.Strength = user.Strength + user.BattleStrength;
                    user.BattleStrength = 0;
                    user.Location = location;
                    await _context.Users.FindOneAndReplaceAsync(x => x.PlayId == PlayId, user);
                }
            }
            return user;
        }

        public async Task<List<User>> GetUsers(Expression<Func<User, bool>> expr) =>
            (await _context.Users.FindAsync(expr)).ToList();


        public async Task<User> CreateUser(string playId)
        {
           // using var semaphore = new SemaphoreSlim(1);
           // await semaphore.WaitAsync();
           // try
           // {
          //      if (await IsExists(x => x.Username == username))
           //         throw new Exception("User with such username already exists!");
          //      if (await IsExists(x => x.PlayId == playId))
           //         throw new Exception("User with such PlayId already exists!");

                var user = new User(playId);
                await _context.Users.InsertOneAsync(user);
                return user;
         //   }
         //   finally
        //    {
        //        semaphore.Release();
        //    }
        }

        public async Task Delete(User user) =>
            await _context.Users.DeleteOneAsync(u => u.PlayId == user.PlayId);
    }
}
