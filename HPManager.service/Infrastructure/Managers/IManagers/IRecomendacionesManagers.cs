using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Models;

namespace HPManager.service.Infrastructure.Managers.IManagers
{
    public interface IRecomendacionesManager
    {
        public Task<Recomendation> CrearRecomendacionAsync(SaveRecomendacionesDto recomendacion);
        public Task<List<RecomendacionesDto>> ObtenerRecomendacionesPorDocenteAsync(int docenteId);
        public Task<List<RecomendacionesDto>> ObtenerRecomendacionesAEstudianteAsync(int estudianteId);
        public Task<List<RecomendacionesDto>> ObtenerRecomendacionesAPsicologoAsync(int psicologoId);
    }
}