using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HPManager.service.Infrastructure.Models
{
    [Table("Citas")]
    public class Cita
    {
        [Key]
        public int CitaID { get; set; }
        public int EstudianteId { get; set; }
        public int PsicologoID { get; set; }
        public DateTime FechaHora { get; set; }
        public int EstadoID { get; set; }
        public string Motivo { get; set; } = default!;
        public string? Descripcion { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreateBy { get; set; }
        public bool DebeIrPadre { get; set; }

        [ForeignKey(nameof(EstudianteId))]
        public virtual Estudiante Estudiante { get; set; } = default!;

        [ForeignKey(nameof(PsicologoID))]
        public virtual Psicologo Psicologo { get; set; } = default!;

        [ForeignKey(nameof(EstadoID))]
        public virtual EstadoCita EstadoCita { get; set; } = default!;
        [ForeignKey(nameof(CreateBy))]
        public virtual Usuario Usuario { get; set; } = default!;
    }

}
