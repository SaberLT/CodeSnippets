using CodeSnippets.Database.Repositories.Interfaces;
using CodeSnippets.Entities.Entities;
using CodeSnippets.Services.Exceptions;
using CodeSnippets.Services.Interfaces;
using CodeSnippets.Services.ViewModels;
using CodeSnippets.Utils;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Services.Implementations
{
    [DependencyInjection(typeof(IAuthService), DependencyInjectionScope.Scoped)]
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;



        private readonly List<char> _charToRemove = new List<char>() { '{', '}', '[', ']' };

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<GithubUserInfoViewModel> GithubSignInOrSignUpUser(GithubAuthViewModel authData)
        {
            // TODO TO DATA ASAP (AddServicesASAPCHANGEDI())
            var tokenUri = "https://github.com/login/oauth/access_token";
            var succUri = "http://localhost:3000/auth/github";
            var clientId = "32fd693e1152e5c78d53";
            var clientSecret = "fe6244d2de62ecee6c501fd30f0ea2dafbf92a93";
            var baseUrl = $"{tokenUri}?scope=user:email&client_id={clientId}&client_secret={clientSecret}&code={authData.Code}&state={authData.State}&redirect_uri={succUri}";

            using (var client = new HttpClient())
            {
                var token = "";
                using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                using (HttpContent content = res.Content)
                {
                    string data = await content.ReadAsStringAsync();
                    if (data != null)
                    {
                        token = data.Split(new char[] { '&', '=' })[1];
                        if (token == "bad_verification_code") // This is bad.
                        {
                            throw new GithubBadVerificationCodeException();
                        }
                    }
                }

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.UserAgent.ParseAdd("OAuthTestAppication");
                using (var res2 = await client.GetAsync("https://api.github.com/user"))
                {
                    using (var content = res2.Content)
                    {
                        var cont = await content.ReadAsStringAsync();
                        foreach (var ch in _charToRemove)
                        {
                            cont = cont.Replace($"{ch}", "");
                        }
                        return JsonConvert.DeserializeObject<GithubUserInfoViewModel>('{' + cont + '}');
                    }
                }
            }
        }

        public async Task<bool> IsGithubUserExists(GithubUserInfoViewModel githubUserModel)
        {
            var result = await _userRepository.Query().CountAsync(x => x.AuthType == AuthType.GitHub && x.AuthData == githubUserModel.Id);
            return result > 0;
        }

        public async Task<User> RegisterGithubUser(GithubUserInfoViewModel githubUserModel)
        {
            return await _userRepository.AddAsync(new User()
            {
                AuthType = AuthType.GitHub,
                LastActionDate = DateTime.UtcNow,
                RegisterDate = DateTime.UtcNow,
                Login = githubUserModel.Login,
                Role = Role.User,
                AuthData = githubUserModel.Id,
                Username = githubUserModel.Login
            });
        }

        public async Task<User> LoginGithubUser(GithubUserInfoViewModel githubUserModel)
        {
            var user = await _userRepository.Query().SingleOrDefaultAsync(x => x.AuthData == githubUserModel.Id && x.AuthType == AuthType.GitHub);
            user.LastActionDate = DateTime.UtcNow;
            return _userRepository.Update(user);
        }

        public async Task<VkResponseViewModel> VkSignInOrSignUpUser(VkRequestViewModel vkUserModel)
        {
            var reqUrl = $"https://api.vk.com/method/users.get?user_ids={vkUserModel.UserId}&fields=photo_50&access_token={vkUserModel.AccessToken}&v=5.101";

            using (var client = new HttpClient())
            {
                using (var res = await client.GetAsync(reqUrl))
                using (var content = res.Content)
                {
                    var data = await content.ReadAsStringAsync();
                    data = data.Replace("\\\"", "\"").Replace("\\/", "/");

                    return JsonConvert
                        .DeserializeObject<VkResponseProxyViewModel>(data)
                        .Response[0];
                }
            }
        }

        public async Task<bool> IsVkUserExists(VkResponseViewModel vkUserModel)
        {
            var result = await _userRepository.Query().CountAsync(x => x.AuthType == AuthType.Vk && x.AuthData == vkUserModel.Id);
            return result > 0;
        }

        public async Task<User> RegisterVkUser(VkResponseViewModel vkUserModel)
        {
            return await _userRepository.AddAsync(new User()
            {
                AuthType = AuthType.Vk,
                LastActionDate = DateTime.UtcNow,
                RegisterDate = DateTime.UtcNow,
                Login = $"{vkUserModel.FirstName} {vkUserModel.LastName}",
                Role = Role.User,
                AuthData = vkUserModel.Id,
                Username = $"{vkUserModel.FirstName} {vkUserModel.LastName}"
            });
        }

        public async Task<User> LoginVkUser(VkResponseViewModel vkUserModel)
        {
            var user = await _userRepository.Query().SingleOrDefaultAsync(x => x.AuthData == vkUserModel.Id && x.AuthType == AuthType.Vk);
            user.LastActionDate = DateTime.UtcNow;
            return _userRepository.Update(user);
        }
    }
}
