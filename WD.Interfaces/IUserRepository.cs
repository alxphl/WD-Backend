using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WD.Entities;

namespace WD.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> IsExists(Expression<Func<User, bool>> expr);
        Task<User> GetByPlayIdSync(string userId);
        Task<List<User>> GetUsers(Expression<Func<User, bool>> expr);
        Task<User> CreateUser(string playId);
        Task Delete(User user);
    }
}
