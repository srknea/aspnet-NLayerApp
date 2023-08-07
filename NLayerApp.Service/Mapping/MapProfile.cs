using AutoMapper;
using NLayerApp.Core.DTOs;
using NLayerApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap(); // ProductDto to Product and Product to ProductDto
            CreateMap<Category, CategoryDto>().ReverseMap(); // CategoryDto to Category and Category to CategoryDto
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();
        }
    }
}
