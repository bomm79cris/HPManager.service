using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Managers.IManagers;
using HPManager.service.Infrastructure.Repositories.IRepositories;

namespace HPManager.service.Infrastructure.Managers
{
    public class ObservacionesManager : IObservacionesManager
    {
        private readonly IObservacionesRepository _observacionesRepository;
        public ObservacionesManager(IObservacionesRepository observacionesRepository) { 
            _observacionesRepository = observacionesRepository;
        }

        public async Task<ICollection<ObservacionesDto>> GetObservationsByEstudianteIDAsync(int EstudianteID)
        {
            return await _observacionesRepository.GetObservationsByEstudianteIDAsync(EstudianteID);
        }
        public async Task<SaveObservacionesDto> CreateObservationAsync(SaveObservacionesDto newObservation)
        {
            return await _observacionesRepository.CreateObservationAsync(newObservation);
        }
    }
}
