using HPManager.service.Infrastructure.Models;

namespace HPManager.service.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Usuario GetUserByEmailAndPassword(string email, string password);
    }
}
