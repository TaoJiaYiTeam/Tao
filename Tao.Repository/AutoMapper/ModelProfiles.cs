using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tao.Domain;

namespace Tao.Repository
{
    public class ModelProfiles : Profile
    {
        public ModelProfiles()
        {
            CreateMap<ProductModel, Product>().ReverseMap();

        }
    }
}
