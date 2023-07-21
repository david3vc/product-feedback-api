using Application.Core;
using Application.Dtos;

namespace Application.Services.Abstractions
{
    public interface IUserService : IServiceCrud<UserDto, UserFormDto, int> 
    {
        Task<UserTokenDto?> LoginAsync(UserLoginDto dto);
    }
}
