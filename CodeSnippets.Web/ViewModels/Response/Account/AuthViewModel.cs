using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippets.Web.ViewModels.Response.Account
{
    public class AuthViewModel
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
