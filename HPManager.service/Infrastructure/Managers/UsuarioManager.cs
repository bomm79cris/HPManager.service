using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Managers.IManagers;
using HPManager.service.Infrastructure.Repositories;

namespace HPManager.service.Infrastructure.Managers
{
    public class UsuarioManager : IUsuarioManager
    {
        private readonly IUserRepository _userRepository;
        public UsuarioManager(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public async Task<ICollection<EstudianteDto>> GetEstudiantesAllAsync()
        {
            return await _userRepository.GetEstudiantesAllAsync();
        }
        public async Task<ICollection<EstudianteDto>> GetEstudiantesByPadresId(int padreID)
        {
            return await _userRepository.GetEstudiantesByPadresId(padreID);
        }
    }
}
