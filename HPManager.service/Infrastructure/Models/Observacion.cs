using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HPManager.service.Infrastructure.Models
{
    [Table("Observaciones")]
    public class Observacion
    {
        [Key]
        public int ObservacionID { get; set; }
        public int PsicologoID { get; set; }
        public int EstudianteID { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public DateTime CreatedAt { get; set; } 

        [ForeignKey(nameof(EstudianteID))]
        public virtual Usuario Usuario { get; set; }
        [ForeignKey(nameof(PsicologoID))]
        public virtual Psicologo Psicologo { get; set; }
    }

}
