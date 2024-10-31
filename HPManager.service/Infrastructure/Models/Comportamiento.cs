using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HPManager.service.Infrastructure.Models
{
    [Table("Comportamiento")]
    public class Comportamiento
    {
        [Key]
        public int ComportamientoID { get; set; }
        public int DocenteID { get; set; }
        public int EstudianteID { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public DateTime CreatedAt { get; set; } 

        [ForeignKey(nameof(DocenteID))]
        public virtual Docente Docente { get; set; }

        [ForeignKey(nameof(EstudianteID))]
        public virtual Estudiante Estudiante { get; set; }
    }
}
