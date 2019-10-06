using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using CodeSnippets.Database.Concrete.Interfaces;
using CodeSnippets.Entities.Entities;
using CodeSnippets.Services.Interfaces;
using CodeSnippets.Services.ViewModels;
using CodeSnippets.Utils.Interfaces;
using CodeSnippets.Utils.ResponseCreators;
using CodeSnippets.Web.ViewModels.Response.Account;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CodeSnippets.Web.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    [EnableCors("DefaultCorsPolicy")]
    public class OAuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ICodeSnippetsUnitOfWork _uow;
        private readonly IResponseCreator _responseCreator;
        private readonly IMapper _mapper;
        private readonly IUserTokenCreator _tokenCreator;
        public OAuthController(IAuthService authService, ICodeSnippetsUnitOfWork uow,
            IResponseCreator responseCreator, IMapper mapper,
            IUserTokenCreator tokenCreator)
        {
            _authService = authService;
            _uow = uow;
            _responseCreator = responseCreator;
            _mapper = mapper;
            _tokenCreator = tokenCreator;
        }

        [HttpPost]
        [Route("githubAuth")]
        public async Task<ResponseViewModel> GithubAuth([FromBody] GithubAuthViewModel authData)
        {
            var userInfo = await _authService.GithubSignInOrSignUpUser(authData);

            User user = null;

            if (await _authService.IsGithubUserExists(userInfo))
                user = await _authService.LoginGithubUser(userInfo);
            else
                user = await _authService.RegisterGithubUser(userInfo);
                    
            await _uow.CommitAsync();

            var authViewModel = _mapper.Map<AuthViewModel>(user);

            authViewModel.Token = _tokenCreator.CreateToken(JsonConvert.SerializeObject(user));

            return _responseCreator.CreateSuccess(authViewModel);
        }


        [HttpPost]
        [Route("vkAuth")]
        public async Task<ResponseViewModel> VkAuth([FromBody]VkRequestViewModel authData)
        {
            var userInfo = await _authService.VkSignInOrSignUpUser(authData);

            User user = null;

            if (await _authService.IsVkUserExists(userInfo))
                user = await _authService.LoginVkUser(userInfo);
            else
                user = await _authService.RegisterVkUser(userInfo);

            await _uow.CommitAsync();

            var authViewModel = _mapper.Map<AuthViewModel>(user);

            authViewModel.Token = _tokenCreator.CreateToken(JsonConvert.SerializeObject(user));

            return _responseCreator.CreateSuccess(authViewModel);
        }
    }
}