using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Managers.IManagers;
using HPManager.service.Infrastructure.Models;
using HPManager.service.Infrastructure.Repositories.IRepositories;
namespace HPManager.service.Infrastructure.Managers
{
    public class ComportamientosManager : IComportamientosManager
    {
        private readonly IComportamientosRepository _repository;

        public ComportamientosManager(IComportamientosRepository repository)
        {
            _repository = repository;
        }

        public async Task<Comportamiento> CrearComportamientoAsync(SaveComportamientoDto comportamiento)
        {
            return await _repository.CrearComportamientoAsync(comportamiento);
        }

        public async Task<List<ComportamientoDto>> ObtenerComportamientosPorEstudianteAsync(int estudianteId, int userId)
        {
            return await _repository.ObtenerComportamientosPorEstudianteAsync(estudianteId, userId);
        }

        public async Task<Comportamiento> UpdateComportamiento(int idComportamiento, string newObservation)
        {
            return await _repository.UpdateComportamiento(idComportamiento, newObservation);
        }
        public async Task<int> DeleteComportamientoAsync(int idComportamiento)
        {
            return await _repository.DeleteComportamientoAsync(idComportamiento);
        }
    }

}