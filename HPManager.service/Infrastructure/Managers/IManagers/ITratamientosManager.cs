using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Models;

namespace HPManager.service.Infrastructure.Managers.IManagers
{
    public interface ITratamientosManager
    {
        public Task<ICollection<GetTratamientoDto>> GetTratamientosByEstudianteID(int estudianteID);
        public Task<int> CambiarEstadoDeUnTratamientoAsync(int newEstadoId, int tratamientoId);
        public Task<Tratamiento> CrearTratamientoParaUnEstudiante(NewTratamientoDto newTratamiento);
        public Task<UpdateTratamientoDto> EditarTratamientoParaUnEstudiante(UpdateTratamientoDto newTratamiento, int tratamientoID);
        public Task<int> DeleteTratamientoParaUnEstudiante(int tratamientoID);
    }
}
