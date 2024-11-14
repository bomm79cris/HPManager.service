using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Models;
using HPManager.service.Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HPManager.service.Infrastructure.Repositories
{
    public class RecomendacionesRepository : IRecomendacionesRepository
    {
        public async Task CrearRecomendacionAsync(SaveRecomendacionesDto recomendacion)
        {
            await _context.Recomendaciones.AddAsync(recomendacion);
            await _context.SaveChangesAsync();
        }
        public async Task<List<RecomendacionesDto>> ObtenerRecomendacionesPorDocenteAsync(int docenteId)
        {
            return await _context.Recomendaciones
                .Where(r => r.DocenteId == docenteId)
                .ToListAsync();
        }
        public async Task<List<RecomendacionesDto>> ObtenerRecomendacionesAEstudianteAsync(int estudianteId)
        {
            return await _context.Recomendaciones
                .Where(r => r.EstudianteId == estudianteId)
                .ToListAsync();
        }
        public async Task<List<RecomendacionesDto>> ObtenerRecomendacionesAPsicologoAsync(int psicologoId)
        {
            return await _context.Recomendaciones
                .Where(r => r.PsicologoId == psicologoId)
                .ToListAsync();
        }


    }
}