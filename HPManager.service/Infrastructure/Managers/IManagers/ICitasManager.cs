using HPManager.service.Infrastructure.Dtos;

namespace HPManager.service.Infrastructure.Managers.IManagers
{
    public interface ICitasManager
    {
        public Task<ICollection<GetCitasDto>> GetCitasByEstudianteIdAsync(int estudianteId);
        public Task<ICollection<GetCitasDto>> GetCitasByPsicologoIdAsync(int psicologoId);
        public Task<int> DeleteCitasByIdAsync(int citaId);
        public Task<CitasDto> CreateNewCitaAsync(CitasDto citasDto);
        public Task<int> CambiarEstadoCitaAsync(int citaId, int newEstadoCitaId);
        public Task<UpdateCitaDto> UpdateCitaByIdAsync(int citaId, UpdateCitaDto updateCitaDto);
    }
}
