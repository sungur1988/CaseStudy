using AutoMapper;
using Core.Dtos;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<AppUser,RegisterRequestDto>().ReverseMap();
            CreateMap<AppUser,RegisterResponseDto>().ReverseMap();
        }
    }
}
