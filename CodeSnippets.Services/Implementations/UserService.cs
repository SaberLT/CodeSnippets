using AutoMapper;
using CodeSnippets.Database.Concrete.Interfaces;
using CodeSnippets.Database.Repositories.Interfaces;
using CodeSnippets.Entities.Entities;
using CodeSnippets.Services.Exceptions;
using CodeSnippets.Services.Interfaces;
using CodeSnippets.Services.ViewModels;
using CodeSnippets.Utils;
using CodeSnippets.Utils.Interfaces;
using CodeSnippets.Utils.ResponseCreators;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Services.Implementations
{
    [DependencyInjection(typeof(IUserService), DependencyInjectionScope.Scoped)]
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserPasswordEncoder _encoder;
        private readonly IUserTokenCreator _tokenCreator;

        private readonly ICodeSnippetsUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, ICodeSnippetsUnitOfWork uow,
            IMapper mapper, IUserPasswordEncoder _encoder, 
            IUserTokenCreator tokenCreator)
        {
            _userRepository = userRepository;
            _tokenCreator = tokenCreator;

            _mapper = mapper;
            _uow = uow;
        }
        public UserViewModel CheckToken(string token)
        {
            return JsonConvert.DeserializeObject<UserViewModel>(_tokenCreator.DecodeToken(token));
        }

        public string GenerateToken(UserViewModel model)
        {
            return _tokenCreator.CreateToken(JsonConvert.SerializeObject(model));
        }

        public async Task<User> Login(string login, string password)
        {
            if(!await IsUserExists(login))
                throw new UserNotFoundException($"User {login} doesn't exist.");

            var user = await _userRepository.Query().SingleOrDefaultAsync(x => x.Login == login && x.AuthData == _encoder.EncodeUserPassword(password));
            if (user == null)
                throw new UserAuthException($"Wrong auth data");

            return user;
        }

        public async Task<User> Register(string login, string password)
        {
            if(await IsUserExists(login))
                throw new UserAlreadyExistsException($"User {login} has already exists.");

            var encodedPassword = _encoder.EncodeUserPassword(password);
                       
            await _userRepository.AddAsync(new User()
            {
                Login = login,
                AuthData = encodedPassword,
                RegisterDate = DateTime.UtcNow,
                LastActionDate = DateTime.UtcNow,
                Role = Role.User,
                AuthType = AuthType.Standard,
                Username = login
            });

            await _uow.CommitAsync();

            var newUser = await _userRepository.Query().SingleOrDefaultAsync(x => x.Login == login);
            return newUser;
        }

        public async Task<User> GetUserById(long id)
        {
            return await _userRepository.GetByIdAsync(id);
        }
        public async Task<bool> IsUserExists(string login)
        {
            return await _userRepository.Query().SingleOrDefaultAsync(x => x.Login == login) == null;
        }
    }
}
