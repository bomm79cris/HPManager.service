using HPManager.service.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HPManager.service.Infrastructure.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<RolUsuario> RolUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Psicologo> Psicologos { get; set; }
        public DbSet<PadreDeFamilia> PadresDeFamilia { get; set; }
        public DbSet<EstadoCita> EstadosCitas { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Observacion> Observaciones { get; set; }
        public DbSet<EstadoTratamiento> EstadoTratamientos { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<Comportamiento> Comportamientos { get; set; }
        public DbSet<Recomendation> Recomendaciones { get; set; }
    }
}
