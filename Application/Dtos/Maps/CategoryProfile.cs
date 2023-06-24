using AutoMapper;
using Domain;

namespace Application.Dtos.Maps
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
