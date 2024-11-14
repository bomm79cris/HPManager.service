using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Managers.IManagers;
using HPManager.service.Infrastructure.Repositories.IRepositories;
namespace HPManager.service.Infrastructure.Managers
{
    public class ComportamientoManagers()
    {
        public class ComportamientosManager : IComportamientosManager
        {
            private readonly IComportamientosRepository _repository;

            public ComportamientosManager(IComportamientosRepository repository)
            {
                _repository = repository;
            }

            public async Task CrearComportamientoAsync(SaveComportamientoDto comportamiento)
            {
                await _repository.CrearComportamientoAsync(comportamiento);
            }

            public async Task<List<ComportamientoDto>> ObtenerComportamientosPorEstudianteAsync(int estudianteId)
            {
                return await _repository.ObtenerComportamientosPorEstudianteAsync(estudianteId);
            }

            public async Task<List<ComportamientoDto>> ObtenerComportamientosPorDocenteAsync(int docenteId)
            {
                return await _repository.ObtenerComportamientosPorDocenteAsync(docenteId);
            }
        }

    }
}