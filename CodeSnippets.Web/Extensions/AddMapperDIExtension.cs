using AutoMapper;
using CodeSnippets.Web.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippets.Web.Extensions
{
    public static class AddMapperDIExtension
    {
        public static void AddMapperDI(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                // TODO ADD ATTRIBUTE AND GET BY REFLECTION EVERY MAPPING
                mc.AddProfile(new ViewModelsMappings());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
