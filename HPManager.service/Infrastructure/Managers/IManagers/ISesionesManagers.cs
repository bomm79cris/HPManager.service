using HPManager.service.Infrastructure.Dtos;

namespace HPManager.service.Infrastructure.Managers.IManagers
{ 
    public interface ISesionesManager
    {
        Task CrearSesionAsync(SaveSesionesDto sesion);
        Task<List<SesionesDto>> ObtenerSesionesPorPsicologoAsync(int psicologoId);
        Task<List<SesionesDto>> ObtenerSesionesAEstudianteAsync(int estudianteId);
        Task EditarSesionAsync(SaveSesionesDto sesion);
        Task EliminarSesionAsync(int sesionId);
    }
}