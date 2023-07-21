using Domain;
using Infraestructure.Core;

namespace Infraestructure.Repositories.Abstractions
{
    public interface IUserRepository : IRepositoryCrud<User, int> 
    {
        Task<User?> LoginAsync(string username, string password);
    }
}
