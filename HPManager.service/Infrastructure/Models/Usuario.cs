using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HPManager.service.Infrastructure.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        public Usuario() {
            Docentes = new HashSet<Docente>();
            Estudiantes = new HashSet<Estudiante>();
            Psicologos = new HashSet<Psicologo>();
            PadresDeFamilia = new HashSet<PadreDeFamilia>();
            CitasCreadas = new HashSet<Cita>();
        }
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public int RolID { get; set; }
        public DateTime Created_at { get; set; }
        [ForeignKey(nameof(RolID))]
        public virtual RolUsuario Rol { get; set; }
        [InverseProperty(nameof(Docente.Usuario))]
        public virtual ICollection<Docente> Docentes { get; set; }
        [InverseProperty(nameof(Estudiante.Usuario))]
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        [InverseProperty(nameof(Psicologo.Usuario))]
        public virtual ICollection<Psicologo> Psicologos { get; set; }
        [InverseProperty(nameof(PadreDeFamilia.Usuario))]
        public virtual ICollection<PadreDeFamilia> PadresDeFamilia { get; set; }
        [InverseProperty(nameof(Cita.Usuario))]
        public virtual ICollection<Cita> CitasCreadas { get; set; }

    }
}
