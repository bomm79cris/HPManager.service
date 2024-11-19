using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Models;

namespace HPManager.service.Infrastructure.Managers.IManagers
{ 
    public interface ISesionesManager
    {
        public Task<Sesion> CrearSesionAsync(SaveSesionesDto sesion);
        public Task<List<SesionesDto>> ObtenerSesionesPorPsicologoAsync(int psicologoId);
        public Task<List<SesionesDto>> ObtenerSesionesAEstudianteAsync(int estudianteId);
        public Task<Sesion> EditarSesionAsync(int sesionId, SaveSesionesDto sesionEditada);
        public Task<int> EliminarSesionAsync(int sesionId);
    }
}