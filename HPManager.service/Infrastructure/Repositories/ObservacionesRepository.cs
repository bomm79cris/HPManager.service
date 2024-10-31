using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Models;
using HPManager.service.Infrastructure.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HPManager.service.Infrastructure.Repositories
{
    public class ObservacionesRepository :IObservacionesRepository
    {
        private readonly ApplicationDbContext _context;
        public ObservacionesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<ObservacionesDto>> GetObservationsByEstudianteIDAsync(int EstudianteID)
        {

            return await _context.Observaciones.Where(observacion => observacion.EstudianteID == EstudianteID)
                .Select(observacion => new ObservacionesDto
                {
                    Fecha = observacion.Fecha,
                    Descripcion = observacion.Descripcion,
                    Observaciones = observacion.Observaciones,
                    NombrePsicologo = observacion.Psicologo.Usuario.Nombre

                })
                .ToListAsync();
        }
        public async Task<SaveObservacionesDto> CreateObservationAsync(SaveObservacionesDto newObservation)
        {
            var Observacion = new Observacion
            {
                EstudianteID = newObservation.EstudianteID,
                PsicologoID = newObservation.PsicologoID,
                Descripcion = newObservation.Descripcion,
                Fecha = newObservation.Fecha,
                Observaciones = newObservation.Observaciones
            };
            await _context.AddAsync(Observacion);
            return newObservation;
           
        }
    }
}

