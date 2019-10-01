using CodeSnippets.Database.Concrete;
using CodeSnippets.Database.Concrete.Interfaces;
using CodeSnippets.Services;
using CodeSnippets.Utils;
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
    public static class AddServicesDIExtension
    {
        public static void AddServicesDI(this IServiceCollection services)
        {
            AddContexts(services);
            AddServices(services);
        }

        private static void AddServices(IServiceCollection services)
        {
            var typesFromRepositories = DependencyInjectionAttribute.GetBindingForAssembly(typeof(CodeSnippetsDbContext).Assembly).ToList();
            var typesFromServices = DependencyInjectionAttribute.GetBindingForAssembly(typeof(BaseService).Assembly).ToList();

            AddServicesFromDIAttribute(typesFromRepositories, services);
            AddServicesFromDIAttribute(typesFromServices, services);
        }

        private static void AddContexts(IServiceCollection services)
        {
            services.AddScoped<ICodeSnippetsDbContextFactory, CodeSnippetsDbContextFactory>();
            services.AddScoped<ICodeSnippetsUnitOfWork, CodeSnippetsUnitOfWork>();
            services.AddSingleton<IUserPasswordEncoder, UserPasswordDoubleBase64Encoder>();
            services.AddSingleton<IResponseCreator, ResponseCreator>();
            services.AddSingleton<IUserTokenCreator>(s => new UserTokenHMACCreator("☺☺☺"));
        }

        private static void AddServicesFromDIAttribute(IEnumerable<DependencyInjectionBinding> bindings, IServiceCollection services)
        {
            bindings.ToList().ForEach(x =>
            {
                switch (x.Scope)
                {
                    case DependencyInjectionScope.Scoped:
                        {
                            services.AddScoped(x.Source, x.Destination);
                            break;
                        }
                    case DependencyInjectionScope.Singleton:
                        {
                            services.AddSingleton(x.Source, x.Destination);
                            break;
                        }
                    case DependencyInjectionScope.Transient:
                        {
                            services.AddTransient(x.Source, x.Destination);
                            break;
                        }
                }
            });
        }
    }
}
