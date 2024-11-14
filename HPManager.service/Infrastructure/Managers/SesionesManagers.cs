using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Managers.IManagers;
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

        public async Task CrearSesionAsync(SaveSesionesDto sesion)
        {
            await _repository.CrearSesionAsync(sesion);
        }

        public async Task<List<SesionesDto>> ObtenerSesionesPorPsicologoAsync(int psicologoId)
        {
            return await _repository.ObtenerSesionesPorPsicologoAsync(psicologoId);
        }

        public async Task<List<SesionesDto>> ObtenerSesionesAEstudianteAsync(int estudianteId)
        {
            return await _repository.ObtenerSesionesAEstudianteAsync(estudianteId);
        }

        public async Task EditarSesionAsync(SaveSesionesDto sesion)
        {
            await _repository.EditarSesionAsync(sesion);
        }

        public async Task EliminarSesionAsync(int sesionId)
        {
            await _repository.EliminarSesionAsync(sesionId);
        }
    }
}
