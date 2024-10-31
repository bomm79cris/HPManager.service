using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HPManager.service.Infrastructure.Models
{
    [Table("EstadosCitas")]
    public class EstadoCita
    {
        public EstadoCita() { 
            Citas = new HashSet<Cita>();
        }
        [Key]
        public int EstadoId { get; set; }
        public string Estado {  get; set; }
        [InverseProperty(nameof(Cita.EstadoCita))]
        public virtual ICollection<Cita> Citas { get; set; }
    }
}
