using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Models;

namespace HPManager.service.Infrastructure.Repositories.IRepositories
{
    public interface IRecomendacionesRepository
    {
       public Task<Recomendation> CrearRecomendacionAsync(SaveRecomendacionesDto recomendacion);
        public Task<List<RecomendacionesDto>> ObtenerRecomendacionesPorDocenteAsync(int docenteId);
        public Task<List<RecomendacionesDto>> ObtenerRecomendacionesAEstudianteAsync(int estudianteId);
        public Task<List<RecomendacionesDto>> ObtenerRecomendacionesAPsicologoAsync(int psicologoId);
    }
}
