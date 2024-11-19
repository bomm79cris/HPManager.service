using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Models;

namespace HPManager.service.Infrastructure.Repositories.IRepositories
{

    public interface IComportamientosRepository
    {
        public Task<Comportamiento> CrearComportamientoAsync(SaveComportamientoDto comportamiento);
        public Task<List<ComportamientoDto>> ObtenerComportamientosPorEstudianteAsync(int estudianteId,int userId);
        public Task<Comportamiento> UpdateComportamiento(int idComportamiento, string newObservation);
        public Task<int> DeleteComportamientoAsync(int idComportamiento);

    }
}