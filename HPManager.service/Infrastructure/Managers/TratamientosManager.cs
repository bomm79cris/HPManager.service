using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Managers.IManagers;
using HPManager.service.Infrastructure.Models;
using HPManager.service.Infrastructure.Repositories.IRepositories;

namespace HPManager.service.Infrastructure.Managers
{
    public class TratamientosManager : ITratamientosManager
    {
        private readonly ITratamientosRepository _tratamientosRepository;
        public TratamientosManager(ITratamientosRepository tratamientosRepository) {
            _tratamientosRepository = tratamientosRepository;
        }
        public async Task<ICollection<GetTratamientoDto>> GetTratamientosByEstudianteID(int estudianteID)
        {
            return await _tratamientosRepository.GetTratamientosByEstudianteIDAsync(estudianteID);
        }
        public async Task<int> CambiarEstadoDeUnTratamientoAsync(int newEstadoId, int tratamientoId)
        {
            return await _tratamientosRepository.CambiarEstadoDeUnTratamientoAsync(newEstadoId, tratamientoId);
        }
        public async Task<Tratamiento> CrearTratamientoParaUnEstudiante(NewTratamientoDto newTratamiento)
        {
            return await _tratamientosRepository.CrearTratamientoParaUnEstudianteAsync(newTratamiento);
        }
        public async Task<UpdateTratamientoDto> EditarTratamientoParaUnEstudiante(UpdateTratamientoDto newTratamiento, int tratamientoID)
        {
            return await _tratamientosRepository.EditarTratamientoParaUnEstudianteAsync(newTratamiento, tratamientoID);
        }
        public async Task<int> DeleteTratamientoParaUnEstudiante(int tratamientoID)
        {
            return await _tratamientosRepository.DeleteTratamientoParaUnEstudianteAsync(tratamientoID);
        }
    }
}
