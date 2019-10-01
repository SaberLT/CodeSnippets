using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSnippets.Services.Interfaces;
using CodeSnippets.Utils.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CodeSnippets.Web.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    //TODO ADD ENABLE CORS
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IResponseCreator _responseCreator;
        public AccountController(IUserService userService, IResponseCreator responseCreator)
        {
            _userService = userService;
            _responseCreator = responseCreator;
        }

        [HttpGet]
        [Route("test")]
        public async Task<string> PerformTestQuery()
        {
            return $"Hello, motherfucker!";
        }
    }
}