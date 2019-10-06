using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodeSnippets.Web.Controllers
{
    public class OAuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}