using HPManager.service.Infrastructure.Models;

namespace HPManager.service.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Usuario GetUserByEmailAndPassword(string email, string password)
        {
            var user = _context.Usuarios
                .FirstOrDefault(u => u.Email == email);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Contrasena))
            {
                return user;
            }

            return null;
        }
    }
}
