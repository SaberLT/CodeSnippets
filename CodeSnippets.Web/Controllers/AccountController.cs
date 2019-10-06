using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeSnippets.Services.Exceptions;
using CodeSnippets.Services.Interfaces;
using CodeSnippets.Services.ViewModels;
using CodeSnippets.Utils.Interfaces;
using CodeSnippets.Utils.ResponseCreators;
using CodeSnippets.Web.ViewModels.Request.Account;
using CodeSnippets.Web.ViewModels.Response.Account;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CodeSnippets.Web.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    [EnableCors("DefaultCorsPolicy")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IResponseCreator _responseCreator;
        private readonly IMapper _mapper;
        public AccountController(IUserService userService, IResponseCreator responseCreator,
            IMapper mapper)
        {
            _userService = userService;
            _responseCreator = responseCreator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("signIn")]
        public async Task<ResponseViewModel> SignIn([FromBody]SignInViewModel request)
        {
            try
            {
                var user = await _userService.Login(request.Login, request.Password);

                var authViewModel = _mapper.Map<AuthViewModel>(user);

                authViewModel.Token = _userService.GenerateToken(_mapper.Map<UserViewModel>(user));

                return _responseCreator.CreateSuccess(authViewModel);
            }
            catch(UserNotFoundException)
            {
                return _responseCreator.CreateFailure("User not found.");
            }
            catch(UserAuthException)
            {
                return _responseCreator.CreateFailure("User doesn't exist of password incorrect.");
            }
        }

        [HttpPost]
        [Route("signUp")]
        public async Task<ResponseViewModel> SignUp([FromBody]SignUpViewModel request)
        {
            if (request.Password != request.PasswordConfirmation)
                return _responseCreator.CreateFailure("Password doesn't match confirmation.");

            try
            {
                var newUser = await _userService.Register(request.Login, request.Password);

                var authViewModel = _mapper.Map<AuthViewModel>(newUser);

                authViewModel.Token = _userService.GenerateToken(_mapper.Map<UserViewModel>(newUser));

                return _responseCreator.CreateSuccess(authViewModel);
            }
            catch(UserAlreadyExistsException)
            {
                return _responseCreator.CreateFailure("User is already exists.");
            }
        }

    }
}