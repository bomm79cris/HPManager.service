using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Models;

namespace HPManager.service.Infrastructure.Repositories.IRepositories
{
    public interface ITratamientosRepository
    {
        public Task<ICollection<GetTratamientoDto>> GetTratamientosByEstudianteIDAsync (int estudianteID);
        public Task<int> CambiarEstadoDeUnTratamientoAsync(int newEstadoId, int tratamientoId);
        public Task<Tratamiento> CrearTratamientoParaUnEstudianteAsync(NewTratamientoDto newTratamiento);
        public Task<UpdateTratamientoDto> EditarTratamientoParaUnEstudianteAsync(UpdateTratamientoDto newTratamiento, int tratamientoID);
        public Task<int> DeleteTratamientoParaUnEstudianteAsync(int tratamientoID);
    }
}
