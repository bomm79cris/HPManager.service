using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Enums;
using HPManager.service.Infrastructure.Models;
using HPManager.service.Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HPManager.service.Infrastructure.Repositories
{
    public class TratamientosRepository : ITratamientosRepository
    {
        private readonly ApplicationDbContext _context;
        public TratamientosRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<GetTratamientoDto>> GetTratamientosByEstudianteIDAsync(int estudianteID)
        {
            return await _context.Tratamientos.Where(observacion => observacion.EstudianteID == estudianteID)
               .Select(observacion => new GetTratamientoDto
               {
                   Description = observacion.Description,
                   EstadoID = observacion.EstadoID,
                   FechaFin = observacion.FechaFin,
                   FechaInicio = observacion.FechaInicio,
                   NombreEstado = observacion.EstadoTratamiento.Estado,
                   Titulo = observacion.Titulo

               })
               .ToListAsync();
        }
        public async Task<int> CambiarEstadoDeUnTratamientoAsync(int newEstadoId, int tratamientoId)
        {
            var tratamiento = GetTratamientoByIdAsync(tratamientoId);
            tratamiento.EstadoID = newEstadoId;

            return await _context.SaveChangesAsync();
        }
        public async Task<Tratamiento> CrearTratamientoParaUnEstudianteAsync(NewTratamientoDto newTratamiento)
        {
            var tratamiento = new Tratamiento
            {
                EstadoID = (int )EstadoTratamientos.PENDIENTE,
                EstudianteID = newTratamiento.EstudianteID,
                Description = newTratamiento.Description,
                FechaInicio = newTratamiento.FechaInicio,
                FechaFin = newTratamiento.FechaFin,
                PsicologoID = newTratamiento.PsicologoID,
                Titulo = newTratamiento.Titulo


            };

            await _context.AddAsync( tratamiento );
            await _context.SaveChangesAsync();
            return tratamiento;
        }
        public async Task<UpdateTratamientoDto> EditarTratamientoParaUnEstudianteAsync(UpdateTratamientoDto newTratamiento, int tratamientoID)
        {
            var tratamiento = GetTratamientoByIdAsync(tratamientoID);
            tratamiento.Titulo = newTratamiento.Titulo;
            tratamiento.Description = newTratamiento.Description;
            tratamiento.FechaInicio = newTratamiento.FechaInicio;
            tratamiento.FechaFin = newTratamiento.FechaFin;

            await _context.SaveChangesAsync();
            return newTratamiento;
        }
        public async Task<int> DeleteTratamientoParaUnEstudianteAsync(int tratamientoID)
        {
            var tratamiento = GetTratamientoByIdAsync(tratamientoID);
            _context.Remove(tratamiento);
            return await _context.SaveChangesAsync();
        }
        private  Tratamiento GetTratamientoByIdAsync(int tratamientoId)
        {
            return _context.Tratamientos.Where(tratamiento => tratamiento.TratamientoID == tratamientoId).FirstOrDefault();
        }

    }
}
