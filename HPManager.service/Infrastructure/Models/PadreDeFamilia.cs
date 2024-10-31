using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HPManager.service.Infrastructure.Models
{
    [Table("PadresFamilia")]
    public class PadreDeFamilia
    {
        public PadreDeFamilia() { 
            Estudiantes = new HashSet<Estudiante>();
        }
        [Key]
        public int PadreID { get; set; }
        public string Telefono { get; set; }
        [ForeignKey(nameof(PadreID))]
        public virtual Usuario Usuario { get; set; }
        [InverseProperty(nameof(Estudiante.PadreDeFamilia))]
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        
    }
}
