using HPManager.service.Infrastructure.Dtos;

namespace HPManager.service.Infrastructure.Repositories.IRepositories
{
    public interface IObservacionesRepository 
    {
        public Task<ICollection<ObservacionesDto>> GetObservationsByEstudianteIDAsync(int estudianteID);
        public Task<SaveObservacionesDto> CreateObservationAsync( SaveObservacionesDto newObservation);
    }
}
