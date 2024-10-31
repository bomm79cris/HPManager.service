using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HPManager.service.Infrastructure.Models
{
    [Table("Sesiones")]
    public class Sesion
    {
        [Key]
        public int SesionID { get; set; }
        public int PsicologoID { get; set; }
        public int EstudianteID { get; set; }
        public DateTime FechaHora { get; set; }
        public string Descripcion { get; set; }
        public string ObjetivoAlcanzado { get; set; }
        public string AspectosAMejorar { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(PsicologoID))]
        public virtual Psicologo Psicologo { get; set; }

        [ForeignKey(nameof(EstudianteID))]
        public virtual Estudiante Estudiante { get; set; }
    }

}
