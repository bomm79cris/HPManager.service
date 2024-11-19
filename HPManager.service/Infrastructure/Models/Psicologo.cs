using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HPManager.service.Infrastructure.Models
{
    [Table("Psicologos")]
    public class Psicologo
    {
        public Psicologo() {
            Citas = new HashSet<Cita>();
            Sesiones = new HashSet<Sesion>();
            Recomendaciones = new HashSet<Recomendation>();
            Tratamientos = new HashSet<Tratamiento>();
            Observaciones = new HashSet<Observacion>();
        }
        [Key]
        public int PsicologoID { get; set; }
        public string Especialidad { get; set; }
        [ForeignKey(nameof(PsicologoID))]
        public virtual Usuario Usuario { get; set; }
        [InverseProperty(nameof(Cita.Psicologo))]
        public virtual ICollection<Cita> Citas { get; set; }
        [InverseProperty(nameof(Sesion.Psicologo))]
        public virtual ICollection<Sesion> Sesiones { get; set; }
        [InverseProperty(nameof(Recomendation.Psicologo))]
        public virtual ICollection<Recomendation> Recomendaciones { get; set;}
        [InverseProperty(nameof(Tratamiento.Psicologo))]
        public virtual ICollection<Tratamiento> Tratamientos { get; set; }
        [InverseProperty(nameof(Observacion.Psicologo))]
        public virtual ICollection<Observacion> Observaciones { get; set; }

    }
}
