using HPManager.service.Infrastructure.Dtos;

namespace HPManager.service.Infrastructure.Repositories.IRepositories
{

    public interface IComportamientosRepository
    {
        Task CrearComportamientoAsync(SaveComportamientoDto comportamiento);
        Task<List<ComportamientoDto>> ObtenerComportamientosPorEstudianteAsync(int estudianteId);
        Task<List<ComportamientoDto>> ObtenerComportamientosPorDocenteAsync(int docenteId);
    }
}