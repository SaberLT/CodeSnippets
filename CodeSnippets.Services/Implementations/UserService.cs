using CodeSnippets.Database.Concrete.Interfaces;
using CodeSnippets.Database.Repositories.Interfaces;
using CodeSnippets.Services.Interfaces;
using CodeSnippets.Services.ViewModels;
using CodeSnippets.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Services.Implementations
{
    [DependencyInjection(typeof(IUserService), DependencyInjectionScope.Scoped)]
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICodeSnippetsUnitOfWork _uow;

        //TODO ADD MAPPER

        public UserService(IUserRepository userRepository, ICodeSnippetsUnitOfWork uow)
        {
            _userRepository = userRepository;

            _uow = uow;
            //TODO ADD MAPPER
        }
        public async Task<UserViewModel> CheckToken(string token)
        {
            await _uow.CommitAsync();
            return new UserViewModel();
        }

        public async Task<string> GenerateToken(UserViewModel model)
        {

            return "";
        }

        public async Task<UserViewModel> Login(string login, string password)
        {

            return new UserViewModel();
        }

        public async Task<UserViewModel> Register(string login, string password)
        {

            return new UserViewModel();
        }
    }
}
