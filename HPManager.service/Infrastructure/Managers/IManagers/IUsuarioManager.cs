using HPManager.service.Infrastructure.Dtos;

namespace HPManager.service.Infrastructure.Managers.IManagers
{
    public interface IUsuarioManager
    {
        public Task<ICollection<EstudianteDto>> GetEstudiantesAllAsync();
        public Task<ICollection<EstudianteDto>> GetEstudiantesByPadresId(int padreID);
        public Task<EstudianteDto> GetEstudianteById(int estudianteID);
        public Task<ICollection<PsicologoDto>> GetPsicologosAll();
    }
}
