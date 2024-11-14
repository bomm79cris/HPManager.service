using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Models;
using HPManager.service.Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HPManager.service.Infrastructure.Repositories
{
    public class ComportamientosRepository() : IComportamientosRepository
    {
        private readonly ApplicationDbContext _context;

        public ComportamientosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CrearComportamientoAsync(SaveComportamientoDto comportamiento)
        {
            await _context.Comportamientos.AddAsync(comportamiento);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ComportamientoDto>> ObtenerComportamientosPorEstudianteAsync(int estudianteId)
        {
            return await _context.Comportamientos
                .Where(c => c.EstudianteId == estudianteId)
                .ToListAsync();
        }
        public async Task<List<ComportamientoDto>> ObtenerComportamientosPorDocenteAsync(int docenteId)
        {
            return await _context.Comportamientos
                .Where(c => c.DocenteId == docenteId)
                .ToListAsync();
        }


    }
}
