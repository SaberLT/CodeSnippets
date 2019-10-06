using CodeSnippets.Entities.Entities;
using CodeSnippets.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Services.Interfaces
{
    public interface IAuthService
    {
        //Github
        Task<GithubUserInfoViewModel> GithubSignInOrSignUpUser(GithubAuthViewModel authData);
        Task<bool> IsGithubUserExists(GithubUserInfoViewModel githubUserModel);
        Task<User> RegisterGithubUser(GithubUserInfoViewModel githubUserModel);
        Task<User> LoginGithubUser(GithubUserInfoViewModel githubUserModel);

        //Vk.com
        Task<VkResponseViewModel> VkSignInOrSignUpUser(VkRequestViewModel inputViewModel);
        Task<bool> IsVkUserExists(VkResponseViewModel vkUserModel);
        Task<User> RegisterVkUser(VkResponseViewModel vkUserModel);
        Task<User> LoginVkUser(VkResponseViewModel vkUserModel);
    }
}
