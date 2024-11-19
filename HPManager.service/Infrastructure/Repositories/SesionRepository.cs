using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Models;
using HPManager.service.Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HPManager.service.Infrastructure.Repositories
{
    public class SesionRepository : ISesionesRepository
    {
        private readonly ApplicationDbContext _context;

        public SesionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Sesion> CrearSesionAsync(SaveSesionesDto sesion)
        {
            var nuevaSesion = new Sesion
            {
                PsicologoID = sesion.PsicologoID,
                EstudianteID = sesion.EstudianteID,
                FechaHora = sesion.FechaHora,
                Descripcion = sesion.Descripcion,
                ObjetivoAlcanzado = sesion.ObjetivoAlcanzado,
                AspectosAMejorar = sesion.AspectosAMejorar,
                CreatedAt = DateTime.Now
            };

            await _context.Sesiones.AddAsync(nuevaSesion);
            await _context.SaveChangesAsync();

            return nuevaSesion;
        }

        public async Task<List<SesionesDto>> ObtenerSesionesPorPsicologoAsync(int psicologoId)
        {
            return await _context.Sesiones
                .Where(s => s.PsicologoID == psicologoId)
                .Select(s => new SesionesDto
                {
                    SesionID = s.SesionID,
                    PsicologoID = s.PsicologoID,
                    PsicologoNombre = s.Psicologo.Usuario.Nombre+" "+s.Psicologo.Usuario.Apellido,
                    EstudianteID = s.EstudianteID,
                    EstudianteNombre = s.Estudiante.Usuario.Nombre + " " + s.Estudiante.Usuario.Apellido,
                    FechaHora = s.FechaHora,
                    Descripcion = s.Descripcion,
                    ObjetivoAlcanzado = s.ObjetivoAlcanzado,
                    AspectosAMejorar = s.AspectosAMejorar,
                    CreatedAt = s.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<List<SesionesDto>> ObtenerSesionesAEstudianteAsync(int estudianteId)
        {
            return await _context.Sesiones
                .Where(s => s.EstudianteID == estudianteId)
                .Select(s => new SesionesDto
                {
                    SesionID = s.SesionID,
                    PsicologoID = s.PsicologoID,
                    PsicologoNombre = s.Psicologo.Usuario.Nombre + " " + s.Psicologo.Usuario.Apellido,
                    EstudianteID = s.EstudianteID,
                    EstudianteNombre = s.Estudiante.Usuario.Nombre + " " + s.Estudiante.Usuario.Apellido,
                    FechaHora = s.FechaHora,
                    Descripcion = s.Descripcion,
                    ObjetivoAlcanzado = s.ObjetivoAlcanzado,
                    AspectosAMejorar = s.AspectosAMejorar,
                    CreatedAt = s.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<Sesion> EditarSesionAsync(int sesionId, SaveSesionesDto sesionEditada)
        {
            var sesion = await _context.Sesiones.FindAsync(sesionId);

            if (sesion == null)
                throw new Exception($"No se encontró la sesión con ID {sesionId}.");

            sesion.FechaHora = sesionEditada.FechaHora;
            sesion.Descripcion = sesionEditada.Descripcion;
            sesion.ObjetivoAlcanzado = sesionEditada.ObjetivoAlcanzado;
            sesion.AspectosAMejorar = sesionEditada.AspectosAMejorar;

            _context.Sesiones.Update(sesion);
            await _context.SaveChangesAsync();

            return sesion;
        }

        public async Task<int> EliminarSesionAsync(int sesionId)
        {
            var sesion = await _context.Sesiones.FindAsync(sesionId);


            _context.Sesiones.Remove(sesion);
            return await _context.SaveChangesAsync();
        }
    }
}
