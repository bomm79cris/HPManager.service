using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Models;
using HPManager.service.Infrastructure.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;

namespace HPManager.service.Infrastructure.Repositories
{
    public class ComportamientosRepository : IComportamientosRepository
    {
        private readonly ApplicationDbContext _context;

        public ComportamientosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Comportamiento> CrearComportamientoAsync(SaveComportamientoDto comportamiento)
        {
            var comportamientoNuevo = new Comportamiento
            {
                Fecha = comportamiento.Fecha,
                DocenteID = comportamiento.DocenteID,
                EstudianteID = comportamiento.EstudianteID,
                Observaciones = comportamiento.Observaciones,
                created_at = DateTime.Now
            };
            await _context.Comportamientos.AddAsync(comportamientoNuevo);
            await _context.SaveChangesAsync();
            return comportamientoNuevo;
        }

        public async Task<List<ComportamientoDto>> ObtenerComportamientosPorEstudianteAsync(int estudianteId,int userID)
        {
            var com= await _context.Comportamientos
                .Where(c => c.EstudianteID == estudianteId).Select(c=>
                new ComportamientoDto
                {
                    ComportamientoID = c.ComportamientoID,
                    CreatedAt = c.created_at,
                    Fecha = c.Fecha,
                    DocenteID= c.DocenteID,
                    Observaciones = c.Observaciones,
                    DocenteFullName = c.Docente.Usuario.Nombre + " " + c.Docente.Usuario.Apellido,
                    SoyElCreador = (c.DocenteID==userID)

                })
                .ToListAsync();
            return com;
        }
        public async Task<Comportamiento> UpdateComportamiento(int idComportamiento, string newObservation)
        {
            var comportamiento = await _context.Comportamientos.Where(c=> c.ComportamientoID==idComportamiento).FirstOrDefaultAsync();
            comportamiento.Observaciones = newObservation;
            
            await _context.SaveChangesAsync();
            return comportamiento;

        }

        public async Task<int> DeleteComportamientoAsync(int idComportamiento)
        {
            var comportamiento = await _context.Comportamientos.Where(c => c.ComportamientoID == idComportamiento).FirstOrDefaultAsync();
                    _context.Remove(comportamiento);
            return await _context.SaveChangesAsync();
            
        }



    }
}
