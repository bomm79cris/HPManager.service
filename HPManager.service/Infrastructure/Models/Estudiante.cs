using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HPManager.service.Infrastructure.Models
{
    [Table("Estudiantes")]
    public class Estudiante
    {
        public Estudiante() { 
            Comportamientos= new HashSet<Comportamiento>();
            Recomendaciones = new HashSet<Recomendation>();
            Citas = new HashSet<Cita>();
            Tratamientos = new HashSet<Tratamiento>();
            Observaciones = new HashSet<Observacion>();
            Sesiones = new HashSet<Sesion>();
        }
        [Key]
        public int EstudianteID { get; set; }
        public int PadreFamiliaID { get; set; }
        public string Grado { get; set; }
        [ForeignKey(nameof(EstudianteID))]
        public virtual Usuario Usuario { get; set; }
        [ForeignKey(nameof(PadreFamiliaID))]
        public virtual PadreDeFamilia PadreDeFamilia { get; set; }
        [InverseProperty(nameof(Comportamiento.Estudiante))]
        public virtual ICollection<Comportamiento> Comportamientos { get; set; }
        [InverseProperty(nameof(Recomendation.Estudiante))]
        public virtual ICollection<Recomendation> Recomendaciones { get; set; }
        [InverseProperty(nameof(Cita.Estudiante))]
        public virtual ICollection<Cita> Citas { get; set; }
        [InverseProperty(nameof(Tratamiento.Estudiante))]
        public virtual ICollection<Tratamiento> Tratamientos { get; set; }
        [InverseProperty(nameof(Observacion.Usuario))]
        public virtual ICollection<Observacion> Observaciones { get; set; }
        [InverseProperty(nameof(Sesion.Estudiante))]
        public virtual ICollection<Sesion> Sesiones { get; set; }


    }
}
