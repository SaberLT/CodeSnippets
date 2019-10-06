using CodeSnippets.Entities.Entities;
using CodeSnippets.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel CheckToken(string token);
        string GenerateToken(UserViewModel model);
        Task<User> Login(string login, string password);
        Task<User> Register(string login, string password);
        Task<User> GetUserById(long id);
        Task<bool> IsUserExists(string login);
    }
}
