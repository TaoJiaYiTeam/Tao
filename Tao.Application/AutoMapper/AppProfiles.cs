using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tao.Domain;
using Tao.Facade;

namespace Tao.Application
{
    public class AppProfiles:Profile
    {
        public AppProfiles()
        {
            CreateMap<Product, ProductVm>().ReverseMap();
            CreateMap<ProductVm, CartVm>().ReverseMap();

            CreateMap<User, UserVm>().ReverseMap();
            CreateMap<Role, RoleVm>().ReverseMap();
            CreateMap<Menu, MenuVm>().ReverseMap();

            CreateMap<UserSearch, UserSearchVm>().ReverseMap();
        }
    }
}
