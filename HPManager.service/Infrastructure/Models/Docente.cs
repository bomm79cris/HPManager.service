using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HPManager.service.Infrastructure.Models
{
    [Table("Docentes")]
    public class Docente
    {
        public Docente() { 
            Comportamientos = new HashSet<Comportamiento>();
            Recomendaciones = new HashSet<Recomendation>();
        }
        [Key]
        public int DocenteID { get; set; }
        public string Asignatura { get; set; }
        [ForeignKey(nameof(DocenteID))]
        public virtual Usuario Usuario { get; set; }
        [InverseProperty(nameof(Comportamiento.Docente))]
        public virtual ICollection<Comportamiento> Comportamientos { get; set; }
        [InverseProperty(nameof(Recomendation.Docente))]
        public virtual ICollection<Recomendation> Recomendaciones { get; set; }
    }
}
