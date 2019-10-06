using CodeSnippets.Utils.Interfaces;
using CodeSnippets.Utils.ResponseCreators;
using CodeSnippets.Utils.User;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippets.Web.Extensions
{
    public static class AddUtilityDIExtension
    {
        public static void AddUtilityDI(this IServiceCollection services)
        {
            services.AddSingleton<IResponseCreator, ResponseCreator>();
            services.AddSingleton<IUserPasswordEncoder, UserPasswordBase64Encoder>();
            services.AddSingleton(typeof(IUserTokenCreator), new UserTokenHMACCreator("123"));
        }
    }
}
