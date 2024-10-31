using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HPManager.service.Infrastructure.Models
{
    [Table("Recomendaciones")]
    public class Recomendation
    {
        [Key]
        public int RecomendacionID { get; set; }
        public int DocenteID { get; set; }
        public int PsicologoID { get; set; }
        public int EstudianteID { get; set; }
        public DateTime Fecha { get; set; }
        public string Recomendacion { get; set; }
        public DateTime CreatedAt { get; set; } 

        [ForeignKey(nameof(DocenteID))]
        public virtual Docente Docente { get; set; }

        [ForeignKey(nameof(PsicologoID))]
        public virtual Psicologo Psicologo { get; set; }

        [ForeignKey(nameof(EstudianteID))]
        public virtual Estudiante Estudiante { get; set; }
    }

}
