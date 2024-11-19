using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Models;
using HPManager.service.Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HPManager.service.Infrastructure.Repositories
{
    public class RecomendacionesRepository : IRecomendacionesRepository
    {
        private readonly ApplicationDbContext _context;
        public RecomendacionesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Recomendation> CrearRecomendacionAsync(SaveRecomendacionesDto recomendacion)
        {
            var newRecomendacion = new Recomendation
            {
                DocenteID = recomendacion.DocenteID,
                EstudianteID = recomendacion.EstudianteID,
                PsicologoID = recomendacion.PsicologoID,
                Recomendacion = recomendacion.Recomendacion,
                Fecha = recomendacion.Fecha,
                created_at = DateTime.Now
            };
            await _context.Recomendaciones.AddAsync(newRecomendacion);
            await _context.SaveChangesAsync();
            return newRecomendacion;
        }
        public async Task<List<RecomendacionesDto>> ObtenerRecomendacionesPorDocenteAsync(int docenteId)
        {
            return await _context.Recomendaciones
                .Where(r => r.DocenteID == docenteId).Select(r=>
                new RecomendacionesDto { 
                Fecha = r.Fecha,
                DocenteID= r.DocenteID,
                CreatedAt = r.created_at,
                EstudianteId = r.EstudianteID,
                Recomendacion = r.Recomendacion,
                nombreDocente = r.Docente.Usuario.Nombre+" "+r.Docente.Usuario.Apellido,
                nombreEstudiante = r.Estudiante.Usuario.Nombre+" "+r.Estudiante.Usuario.Apellido,
                PsicologoId = r.PsicologoID,
                nombrePsicologo = r.Psicologo.Usuario.Nombre+" "+r.Psicologo.Usuario.Apellido
                }
                )
                .ToListAsync();
        }
        public async Task<List<RecomendacionesDto>> ObtenerRecomendacionesAEstudianteAsync(int estudianteId)
        {
            return await _context.Recomendaciones
                .Where(r => r.EstudianteID == estudianteId).Select(r =>
                new RecomendacionesDto
                {
                    Fecha = r.Fecha,
                    DocenteID = r.DocenteID,
                    CreatedAt = r.created_at,
                    EstudianteId = r.EstudianteID,
                    Recomendacion = r.Recomendacion,
                    nombreDocente = r.Docente.Usuario.Nombre + " " + r.Docente.Usuario.Apellido,
                    nombreEstudiante = r.Estudiante.Usuario.Nombre + " " + r.Estudiante.Usuario.Apellido,
                    PsicologoId = r.PsicologoID,
                    nombrePsicologo = r.Psicologo.Usuario.Nombre + " " + r.Psicologo.Usuario.Apellido
                }
                )
                .ToListAsync();
        }
        public async Task<List<RecomendacionesDto>> ObtenerRecomendacionesAPsicologoAsync(int psicologoId)
        {
            return await _context.Recomendaciones
                .Where(r => r.PsicologoID == psicologoId).Select(r =>
                new RecomendacionesDto
                {
                    Fecha = r.Fecha,
                    DocenteID = r.DocenteID,
                    CreatedAt = r.created_at,
                    EstudianteId = r.EstudianteID,
                    Recomendacion = r.Recomendacion,
                    nombreDocente = r.Docente.Usuario.Nombre + " " + r.Docente.Usuario.Apellido,
                    nombreEstudiante = r.Estudiante.Usuario.Nombre + " " + r.Estudiante.Usuario.Apellido,
                    PsicologoId = r.PsicologoID,
                    nombrePsicologo = r.Psicologo.Usuario.Nombre + " " + r.Psicologo.Usuario.Apellido
                }
                )
                .ToListAsync();
        }


    }
}