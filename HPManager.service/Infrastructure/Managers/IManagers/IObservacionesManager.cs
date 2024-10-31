using HPManager.service.Infrastructure.Dtos;

namespace HPManager.service.Infrastructure.Managers.IManagers
{
    public interface IObservacionesManager
    {
        public Task<ICollection<ObservacionesDto>> GetObservationsByEstudianteIDAsync(int estudianteID);
        public Task<SaveObservacionesDto> CreateObservationAsync(SaveObservacionesDto newObservation);
    }
}
