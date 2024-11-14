using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Managers.IManagers;
using HPManager.service.Infrastructure.Repositories.IRepositories;
namespace HPManager.service.Infrastructure.Managers
{ 
public class RecomendacionesManager : IRecomendacionesManager
{
    private readonly IRecomendacionesRepository _repository;

    public RecomendacionesManager(IRecomendacionesRepository repository)
    {
        _repository = repository;
    }

    public async Task CrearRecomendacionAsync(SaveRecomendacionesDto recomendacion)
    {
        await _repository.CrearRecomendacionAsync(recomendacion);
    }

    public async Task<List<RecomendacionesDto>> ObtenerRecomendacionesPorDocenteAsync(int docenteId)
    {
        return await _repository.ObtenerRecomendacionesPorDocenteAsync(docenteId);
    }

    public async Task<List<RecomendacionesDto>> ObtenerRecomendacionesAEstudianteAsync(int estudianteId)
    {
        return await _repository.ObtenerRecomendacionesAEstudianteAsync(estudianteId);
    }

    public async Task<List<RecomendacionesDto>> ObtenerRecomendacionesAPsicologoAsync(int psicologoId)
    {
        return await _repository.ObtenerRecomendacionesAPsicologoAsync(psicologoId);
    }
}
}
