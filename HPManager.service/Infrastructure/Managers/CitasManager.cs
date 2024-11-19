using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Enums;
using HPManager.service.Infrastructure.Managers.IManagers;
using HPManager.service.Infrastructure.Models;
using HPManager.service.Infrastructure.Repositories;
using HPManager.service.Infrastructure.Repositories.IRepositories;

namespace HPManager.service.Infrastructure.Managers
{
    public class CitasManager : ICitasManager
    {
        private readonly ICitasRepository _repository;
        private readonly IUserRepository _usuarioRepository; 

        public CitasManager(ICitasRepository repository, IUserRepository usuarioRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Cita> CreateNewCitaAsync(CitasDto newCitaDto)
        {
            // Validar si el creador es estudiante o psicólogo
            var creador = await _usuarioRepository.GetUsuarioById(newCitaDto.CreateBy);
            if (creador.RolID != (int)Roles.ESTUDIANTE && creador.RolID != (int)Roles.PSICOLOGO)
                throw new HPException("Solo los estudiantes o psicólogos pueden crear citas.");

            // Validar que la fecha no esté en el pasado
            if (newCitaDto.FechaHora < DateTime.Now)
                throw new HPException("La fecha de la cita no puede ser en el pasado.");

            var nuevaCita = new Cita
            {
                EstudianteId = newCitaDto.EstudianteID,
                PsicologoID = newCitaDto.PsicologoID,
                FechaHora = newCitaDto.FechaHora,
                EstadoID = (int)EstadoCitaEnum.SOLICITADA,
                Motivo = newCitaDto.Motivo,
                Descripcion = newCitaDto.Descripcion,
                CreatedAt = DateTime.Now,
                CreateBy = newCitaDto.CreateBy,
                DebeIrPadre = newCitaDto.DebeIrPadre
            };

            await _repository.CreateNewCitaAsync(nuevaCita);
            return nuevaCita;
        }

        public async Task<int> CambiarEstadoCitaAsync(int citaID, int nuevoEstadoID)
        {
            var cita = await _repository.GetCitaById(citaID);

            if (cita == null)
                throw new HPException("La cita especificada no existe.");

            var usuarioActual = await _usuarioRepository.GetUsuarioById(cita.CreateBy);

            // Validar que el estado sea válido
            if (!Enum.IsDefined(typeof(EstadoCitaEnum), nuevoEstadoID))
                throw new HPException("El estado especificado no es válido.");

            // Validar reglas de negocio según el estado actual y el usuario
            switch ((EstadoCitaEnum)nuevoEstadoID)
            {
                case EstadoCitaEnum.CANCELADA:
                    if (cita.CreateBy != usuarioActual.UsuarioId)
                        throw new HPException("Solo el creador de la cita puede cancelarla.");
                    break;

                case EstadoCitaEnum.APROBADA:
                case EstadoCitaEnum.RECHAZADA:
                    if (cita.CreateBy == usuarioActual.UsuarioId)
                        throw new HPException("No puedes aprobar o rechazar tu propia cita.");

                    if (cita.DebeIrPadre && usuarioActual.RolID != (int)Roles.PADRE)
                        throw new HPException("Solo un padre de familia puede aprobar o rechazar esta cita.");
                    break;

                default:
                    throw new HPException("El cambio de estado solicitado no está permitido.");
            }

            // Actualizar el estado de la cita
            cita.EstadoID = nuevoEstadoID;
           return await _repository.CambiarEstadoCitaAsync(citaID, nuevoEstadoID);
        }

        public async Task<ICollection<GetCitasDto>> GetCitasByEstudianteIdAsync(int estudianteID)
        {
            var citas = await _repository.GetCitasByEstudianteIdAsync(estudianteID);

            if (!citas.Any())
                throw new HPException("No se encontraron citas para el estudiante especificado.");

            return citas;
        }

        public async Task<ICollection<GetCitasDto>> GetCitasByPsicologoIdAsync(int psicologoID)
        {
            var citas = await _repository.GetCitasByPsicologoIdAsync(psicologoID);

            if (!citas.Any())
                throw new HPException("No se encontraron citas para el psicólogo especificado.");

            return citas;
        }

        public async Task<int> DeleteCitasByIdAsync(int citaID)
        {
            var cita = await _repository.GetCitaById(citaID);

            if (cita == null)
                throw new HPException("La cita especificada no existe.");

            if (cita.CreateBy != cita.Usuario.UsuarioId)
                throw new HPException("Solo el creador de la cita puede eliminarla.");

            return await _repository.DeleteCitasByIdAsync(citaID);
        }

        public async Task<UpdateCitaDto> UpdateCitaByIdAsync(int citaID, UpdateCitaDto updateCita)
        {
            var cita = await _repository.GetCitaById(citaID);

            if (cita == null)
                throw new HPException("La cita especificada no existe.");

            // Validar cambios antes de actualizar
            if (updateCita.FechaHora < DateTime.Now)
                throw new HPException("La fecha de la cita no puede ser en el pasado.");

            return await _repository.UpdateCitaByIdAsync(citaID, updateCita);
            
        }
    }
}
