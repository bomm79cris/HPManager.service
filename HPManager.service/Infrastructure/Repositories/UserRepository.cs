using HPManager.service.Infrastructure.Dtos;
using HPManager.service.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HPManager.service.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUserByEmailAndPassword(string email, string password)
        {
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email);

           // if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Contrasena))
           // {
              return user;
          //  }

            //return null;
        }
        public async Task<ICollection<EstudianteDto>> GetEstudiantesAllAsync()
        {
            return await _context.Estudiantes.Select(estudiante => 
            new EstudianteDto
            {
                EstudianteId=estudiante.EstudianteID,
                EstudianteName = estudiante.Usuario.Nombre,
                EstudianteApellido =  estudiante.Usuario.Apellido,
                Edad = estudiante.Usuario.Edad,
                Genero = estudiante.Usuario.Genero,
                Grado = estudiante.Grado,
                NombreEstudiante = estudiante.Usuario.Nombre +" "+estudiante.Usuario.Apellido
            }).ToListAsync();
        }
        public async Task<ICollection<EstudianteDto>> GetEstudiantesByPadresId(int padreID)
        {
            return await _context.Estudiantes.Where(estudiante => estudiante.PadreFamiliaID == padreID)
                .Select(estudiante =>
                new EstudianteDto
                {
                    EstudianteId = estudiante.EstudianteID,
                    EstudianteName = estudiante.Usuario.Nombre,
                    EstudianteApellido = estudiante.Usuario.Apellido,
                    Edad = estudiante.Usuario.Edad,
                    Genero = estudiante.Usuario.Genero,
                    Grado = estudiante.Grado,
                    NombreEstudiante = estudiante.Usuario.Nombre + " " + estudiante.Usuario.Apellido

                }).ToListAsync();
        }
        public async Task<ICollection<PsicologoDto>> GetPsicologosAll()
        {
            return await _context.Psicologos.Select(psicologo =>
                    new PsicologoDto
                    {
                        Especializacion = psicologo.Especialidad,
                        PsicologoID = psicologo.PsicologoID,
                        NombrePsicologo = psicologo.Usuario.Nombre + " " + psicologo.Usuario.Apellido
                    }

                ).ToListAsync();
        }
        public async Task<EstudianteDto> GetEstudianteById(int estudianteID)
        {
            return await _context.Estudiantes.Where(estudiante => estudiante.EstudianteID == estudianteID)
                .Select(estudiante =>
                new EstudianteDto
                {
                    EstudianteId = estudiante.EstudianteID,
                    EstudianteName = estudiante.Usuario.Nombre,
                    EstudianteApellido = estudiante.Usuario.Apellido,
                    Edad = estudiante.Usuario.Edad,
                    Genero = estudiante.Usuario.Genero,
                    Grado = estudiante.Grado,
                    NombreEstudiante = estudiante.Usuario.Nombre + " " + estudiante.Usuario.Apellido

                }).FirstOrDefaultAsync();
        }
    }
}
