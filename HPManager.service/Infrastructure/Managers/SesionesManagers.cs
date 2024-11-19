using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Managers.IManagers;
using HPManager.service.Infrastructure.Models;
using HPManager.service.Infrastructure.Repositories.IRepositories;
namespace HPManager.service.Infrastructure.Managers
{
    public class SesionesManager : ISesionesManager
    {
        private readonly ISesionesRepository _repository;

        public SesionesManager(ISesionesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Sesion> CrearSesionAsync(SaveSesionesDto sesion)
        {
           return await _repository.CrearSesionAsync(sesion);
        }

        public async Task<List<SesionesDto>> ObtenerSesionesPorPsicologoAsync(int psicologoId)
        {
            return await _repository.ObtenerSesionesPorPsicologoAsync(psicologoId);
        }

        public async Task<List<SesionesDto>> ObtenerSesionesAEstudianteAsync(int estudianteId)
        {
            return await _repository.ObtenerSesionesAEstudianteAsync(estudianteId);
        }

        public async Task<Sesion> EditarSesionAsync(int sesionId, SaveSesionesDto sesion)
        {
            return await _repository.EditarSesionAsync(sesionId,sesion);
        }

        public async Task<int> EliminarSesionAsync(int sesionId)
        {
            return await _repository.EliminarSesionAsync(sesionId);
        }
    }
}
