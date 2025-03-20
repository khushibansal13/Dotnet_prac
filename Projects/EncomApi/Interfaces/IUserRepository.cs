using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EncomApi.Models;

namespace EncomApi.Interfaces
{
    public interface IUserRepository
    {
        Task<User> RegisterUserAsync(User user, string password);
        Task<User> GetUserByEmailAsync(string email);
        bool VerifyPassword(User user, string password);    
    }
}