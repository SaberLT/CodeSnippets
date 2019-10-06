using AutoMapper;
using CodeSnippets.Entities.Entities;
using CodeSnippets.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippets.Web.Mappings
{
    public class ViewModelsMappings : Profile
    {
        public ViewModelsMappings()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
