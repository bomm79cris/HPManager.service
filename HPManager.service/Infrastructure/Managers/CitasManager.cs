using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Enums;
using HPManager.service.Infrastructure.Managers.IManagers;
using HPManager.service.Infrastructure.Models;
using HPManager.service.Infrastructure.Repositories.IRepositories;

namespace HPManager.service.Infrastructure.Managers
{
    public class CitasManager : ICitasManager
    {
        private readonly ICitasRepository _citasRepository;
        public CitasManager(ICitasRepository citasRepository)
        {
            _citasRepository = citasRepository;
        }
        public async Task<ICollection<GetCitasDto>> GetCitasByEstudianteIdAsync(int estudianteId)
        {
            return await _citasRepository.GetCitasByEstudianteIdAsync(estudianteId);
        }
        public async Task<ICollection<GetCitasDto>> GetCitasByPsicologoIdAsync(int psicologoId)
        {
            return await _citasRepository.GetCitasByPsicologoIdAsync(psicologoId);
        }
        public async Task<int> DeleteCitasByIdAsync(int citaId)
        {
            return await _citasRepository.DeleteCitasByIdAsync(citaId);
        }
        public async Task<Cita> CreateNewCitaAsync(CitasDto citasDto)
        {
            var newCita = new Cita
            {
                CreateBy = citasDto.CreateBy,
                Descripcion = citasDto.Descripcion,
                DebeIrPadre = citasDto.DebeIrPadre,
                EstadoID = (int)EstadoCitaEnum.SOLICITADA,
                EstudianteId = citasDto.EstudianteID,
                FechaHora = citasDto.FechaHora,
                Motivo = citasDto.Motivo,
                PsicologoID = citasDto.PsicologoID,
                CreatedAt = DateTime.Now

            };
            
            return await _citasRepository.CreateNewCitaAsync(newCita); 
        }
        public async Task<int> CambiarEstadoCitaAsync(int citaId, int newEstadoCitaId)
        {
            return await _citasRepository.CambiarEstadoCitaAsync(citaId, newEstadoCitaId);
        }
        public async Task<UpdateCitaDto> UpdateCitaByIdAsync(int citaId, UpdateCitaDto updateCitaDto)
        {
            return await _citasRepository.UpdateCitaByIdAsync(citaId, updateCitaDto);
        }
    }
}
