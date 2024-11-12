using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Models;

namespace HPManager.service.Infrastructure.Managers.IManagers
{
    public interface ICitasManager
    {
        public Task<ICollection<GetCitasDto>> GetCitasByEstudianteIdAsync(int estudianteId);
        public Task<ICollection<GetCitasDto>> GetCitasByPsicologoIdAsync(int psicologoId);
        public Task<int> DeleteCitasByIdAsync(int citaId);
        public Task<Cita> CreateNewCitaAsync(CitasDto citasDto);
        public Task<int> CambiarEstadoCitaAsync(int citaId, int newEstadoCitaId);
        public Task<UpdateCitaDto> UpdateCitaByIdAsync(int citaId, UpdateCitaDto updateCitaDto);
    }
}
