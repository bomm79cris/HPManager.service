using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HPManager.service.Infrastructure.Models
{
    [Table("Tratamientos")]
    public class Tratamiento
    {
        [Key]
        public int TratamientoID { get; set; }
        public int EstudianteID { get; set; }
        public int PsicologoID { get; set; }
        public string Titulo { get; set; }
        public string Description { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; } 
        public int EstadoID { get; set; }
        public DateTime created_at { get; set; }

        [ForeignKey(nameof(EstudianteID))]
        public virtual Estudiante Estudiante { get; set; }

        [ForeignKey(nameof(EstadoID))]
        public virtual EstadoTratamiento EstadoTratamiento { get; set; }
        [ForeignKey(nameof(PsicologoID))]
        public virtual Psicologo Psicologo { get; set; }
    }
}
