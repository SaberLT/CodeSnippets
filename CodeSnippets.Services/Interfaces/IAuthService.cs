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
        Task<GithubUserInfoViewModel> GithubSignInOrSignUpUser(GithubAuthViewModel authData);
        Task<bool> IsGithubUserExists(GithubUserInfoViewModel githubUserModel);
        Task<User> RegisterGithubUser(GithubUserInfoViewModel githubUserModel);
        Task<User> LoginGithubUser(GithubUserInfoViewModel githubUserModel);
    }
}
