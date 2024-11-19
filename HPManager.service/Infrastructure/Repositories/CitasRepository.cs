using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Enums;
using HPManager.service.Infrastructure.Models;
using HPManager.service.Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HPManager.service.Infrastructure.Repositories
{
    public class CitasRepository : ICitasRepository
    {
        private readonly ApplicationDbContext _context;
        public CitasRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<ICollection<GetCitasDto>> GetCitasByEstudianteIdAsync(int estudianteId)
        {
            return await _context.Citas.Where(cita => cita.EstudianteId == estudianteId)
                .Select(cita => new GetCitasDto
                    {
                        CitaId = cita.CitaID,
                        EstudianteId = estudianteId,
                        DebeIrPadre = cita.DebeIrPadre,
                        EstadoID = cita.EstadoID,
                        FechaHora = cita.FechaHora,
                        Motivo = cita.Motivo,
                        NombreEstado = cita.EstadoCita.Estado,
                        NombreEstudiante = cita.Estudiante.Usuario.Nombre+" "+ cita.Estudiante.Usuario.Apellido,
                        PsicologoID = cita.PsicologoID,
                        NombrePsicologo = cita.Psicologo.Usuario.Nombre + " " + cita.Psicologo.Usuario.Apellido,
                        SolicitadoPor = cita.Usuario.Nombre+" "+cita.Usuario.Apellido,
                        EsCancelable = cita.CreateBy == estudianteId,
                        Descripcion = cita.Descripcion

                    }
                
                ).ToListAsync();
        }
        public async Task<ICollection<GetCitasDto>> GetCitasByPsicologoIdAsync(int psicologoId)
        {
            return await _context.Citas.Where(cita => cita.PsicologoID == psicologoId)
               .Select(cita => new GetCitasDto
               {
                   CitaId = cita.CitaID,
                   EstudianteId = cita.EstudianteId,
                   DebeIrPadre = cita.DebeIrPadre,
                   EstadoID = cita.EstadoID,
                   FechaHora = cita.FechaHora,
                   Motivo = cita.Motivo,
                   NombreEstado = cita.EstadoCita.Estado,
                   NombreEstudiante = cita.Estudiante.Usuario.Nombre + " " + cita.Estudiante.Usuario.Apellido,
                   PsicologoID = cita.PsicologoID,
                   NombrePsicologo = cita.Psicologo.Usuario.Nombre + " " + cita.Psicologo.Usuario.Apellido,
                   SolicitadoPor = cita.Usuario.Nombre + " " + cita.Usuario.Apellido,
                   EsCancelable = cita.CreateBy == psicologoId,
                   Descripcion = cita.Descripcion

               }

               ).ToListAsync();
        }
        public async Task<int> DeleteCitasByIdAsync(int citaId)
        {
            var cita = GetCitaById(citaId);
            _context.Remove(cita);
            return await _context.SaveChangesAsync();

        }
        public async Task<Cita> CreateNewCitaAsync(Cita newCita)
        {
          
            await _context.AddAsync(newCita);
            await _context.SaveChangesAsync();
            return newCita;

        }
        public async Task<int> CambiarEstadoCitaAsync(int citaId, int newEstadoCitaId)
        {
            var cita = GetCitaById(citaId);
            cita.EstadoID = newEstadoCitaId;
            return await _context.SaveChangesAsync();

        }
        public async Task<UpdateCitaDto> UpdateCitaByIdAsync(int citaId, UpdateCitaDto updateCitaDto)
        {
            var cita = GetCitaById(citaId);
            cita.FechaHora = updateCitaDto.FechaHora;
            cita.DebeIrPadre = updateCitaDto.DebeIrPadre;
            cita.Descripcion = updateCitaDto.Descripcion;
            cita.EstudianteId = updateCitaDto.EstudianteID;
            cita.PsicologoID = updateCitaDto.PsicologoID;
            cita.Motivo = updateCitaDto.Motivo;
            await _context.SaveChangesAsync();
            return updateCitaDto;
            
        }

        private  Cita GetCitaById (int citaId)
        {
            return  _context.Citas.Where(cita => cita.CitaID == citaId).FirstOrDefault();
        }
    }
}
