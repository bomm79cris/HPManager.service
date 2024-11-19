using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Models;

namespace HPManager.service.Infrastructure.Managers.IManagers
{
    public interface IComportamientosManager
    {
        public Task<Comportamiento> CrearComportamientoAsync(SaveComportamientoDto comportamiento);
        public Task<List<ComportamientoDto>> ObtenerComportamientosPorEstudianteAsync(int estudianteId, int userId);
        public Task<Comportamiento> UpdateComportamiento(int idComportamiento, string newObservation);
        public Task<int> DeleteComportamientoAsync(int idComportamiento);
    }
}