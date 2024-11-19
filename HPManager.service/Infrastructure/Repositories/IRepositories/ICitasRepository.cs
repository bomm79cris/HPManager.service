using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Models;

namespace HPManager.service.Infrastructure.Repositories.IRepositories
{
    public interface ICitasRepository
    {
        public Task<ICollection<GetCitasDto>> GetCitasByEstudianteIdAsync(int estudianteId);
        public Task<ICollection<GetCitasDto>> GetCitasByPsicologoIdAsync(int psicologoId);
        public Task<int> DeleteCitasByIdAsync(int citaId);
        public Task<Cita> CreateNewCitaAsync(Cita citasDto);
        public Task<int> CambiarEstadoCitaAsync(int citaId, int newEstadoCitaId);
        public Task<UpdateCitaDto> UpdateCitaByIdAsync(int citaId,UpdateCitaDto updateCitaDto);
    }
}
