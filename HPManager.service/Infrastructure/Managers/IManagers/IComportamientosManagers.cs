using HPManager.service.Infrastructure.Dtos;

namespace HPManager.service.Infrastructure.Managers.IManagers
{
    public interface IComportamientosManager
    {
        Task CrearComportamientoAsync(SaveComportamientoDto comportamiento);
        Task<List<ComportamientoDto>> ObtenerComportamientosPorEstudianteAsync(int estudianteId);
        Task<List<ComportamientoDto>> ObtenerComportamientosPorDocenteAsync(int docenteId);
    }
}