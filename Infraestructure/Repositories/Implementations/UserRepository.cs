using Core.Security.Services.Abstractions;
using Domain;
using Infraestructure.Context;
using Infraestructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ISecurityService _securityService;

        public UserRepository(ApplicationDbContext context, ISecurityService securityService)
        {
            _context = context;
            _securityService = securityService;
        }

        public async Task<User> Create(User entity)
        {
            var entidad = await _context.Users.FindAsync(entity.Id);

            if (entidad == null)
            {
                entidad = new User();
            }

            entidad.Name = entity.Name;
            entidad.Username = entity.Username;
            entidad.Password = _securityService.HashPassword(entity.Username, entity.Password);

            var validarUsername = await _context.Users.Where(f => f.Username == entity.Username).FirstOrDefaultAsync();
            if (validarUsername?.Username == entity.Username) 
            {
                throw new Exception("El nombre de usuario ya está registrado en el sistema");
            }

            if(entity.Id == 0)
            {
                _context.Users.Add(entidad);
            }
            else
            {
                _context.Users.Update(entidad);
            }

            await _context.SaveChangesAsync();

            return entidad;
        }

        public Task<User?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> Find(int id)
        => await _context.Users.DefaultIfEmpty()
                               .FirstOrDefaultAsync(e => e.Id.Equals(id));

        public async Task<IList<User>> FindAll()
        => await _context.Users.OrderByDescending(e => e.Id)
                               .ToListAsync();

        public async Task<User?> LoginAsync(string username, string password)
        {
            var model = await _context.Users.FirstOrDefaultAsync(e => e.Username == username);

            if (model == null) throw new Exception("Usuario no está registrado en nuestro sistema");

            var verificationResult = _securityService.VerifyHashedPassword(username, model.Password, password);
            if (!verificationResult) throw new Exception("Su contraseña no es correcta");

            return model;
        }

        public async Task<User?> Update(User entity)
        {
            var model = await _context.Users.FindAsync(entity.Id);

            if (model != null)
            {
                model.Username = entity.Username;
                model.Name = entity.Name;

                _context.Users.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
    }
}
