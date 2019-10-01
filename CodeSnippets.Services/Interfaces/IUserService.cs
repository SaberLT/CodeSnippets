using CodeSnippets.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> Login(string login, string password);
        Task<UserViewModel> Register(string login, string password);
        Task<string> GenerateToken(UserViewModel model);
        Task<UserViewModel> CheckToken(string token);
    }
}
