using HPManager.service.Infrastructure.Dtos;

namespace HPManager.service.Infrastructure.Managers.IManagers
{
    public interface IRecomendacionesManager
    {
        Task CrearRecomendacionAsync(SaveRecomendacionesDto recomendacion);
        Task<List<RecomendacionesDto>> ObtenerRecomendacionesPorDocenteAsync(int docenteId);
        Task<List<RecomendacionesDto>> ObtenerRecomendacionesAEstudianteAsync(int estudianteId);
        Task<List<RecomendacionesDto>> ObtenerRecomendacionesAPsicologoAsync(int psicologoId);
    }
}