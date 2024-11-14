using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Models;
using HPManager.service.Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HPManager.service.Infrastructure.Repositories


{
    public class SesionRepository() : ISesionesRepository
    {
        public async Task CrearSesionAsync(SaveSesionesDto sesion)
        {
            await _context.Sesiones.AddAsync(sesion);
            await _context.SaveChangesAsync();
        }
        public async Task<List<SesionesDto>> ObtenerSesionesPorPsicologoAsync(int psicologoId)
        {
            return await _context.Sesiones
                .Where(s => s.PsicologoId == psicologoId)
                .ToListAsync();
        }
        public async Task<List<SesionesDto>> ObtenerSesionesAEstudianteAsync(int estudianteId)
        {
            return await _context.Sesiones
                .Where(s => s.EstudianteId == estudianteId)
                .ToListAsync();
        }
        public async Task EditarSesionAsync(SesionesDto sesion)
        {
            _context.Sesiones.Update(sesion);
            await _context.SaveChangesAsync();
        }
        public async Task EliminarSesionAsync(int sesionId)
        {
            var sesion = await _context.Sesiones.FindAsync(sesionId);
            if (sesion != null)
            {
                _context.Sesiones.Remove(sesion);
                await _context.SaveChangesAsync();
            }
        }

    }
}