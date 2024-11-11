using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Models;

namespace HPManager.service.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        public Task<Usuario> GetUserByEmailAndPassword(string email, string password);
        public Task<ICollection<EstudianteDto>> GetEstudiantesAllAsync();
        public Task<ICollection<EstudianteDto>> GetEstudiantesByPadresId(int padreID);
    }
}
