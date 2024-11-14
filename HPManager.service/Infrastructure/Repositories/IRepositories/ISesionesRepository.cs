using HPManager.service.Infrastructure.Dtos;

namespace HPManager.service.Infrastructure.Repositories.IRepositories
{

    public interface ISesionesRepository
    {
        Task CrearSesionAsync(SaveSesionesDto sesion);
        Task<List<SesionesDto>> ObtenerSesionesPorPsicologoAsync(int psicologoId);
        Task<List<SesionesDto>> ObtenerSesionesAEstudianteAsync(int estudianteId);
        Task EditarSesionAsync(SesionesDto sesion);
        Task EliminarSesionAsync(int sesionId);
    }
}