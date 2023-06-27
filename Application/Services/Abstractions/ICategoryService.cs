using Application.Dtos;
using Domain;

namespace Application.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<IList<CategoryDto>> FindAll();
    }
}
