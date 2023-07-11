using AutoMapper;
using Domain.Dto;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mapper
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Categorium, CategoriumDTO>().ReverseMap();
            CreateMap<Producto, ProductoDTO>().ReverseMap();
        }
    }
}
