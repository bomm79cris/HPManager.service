using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HPManager.service.Infrastructure.Models
{
    [Table("EstadosTratamientos")]
    public class EstadoTratamiento
    {
        public EstadoTratamiento() {
            Tratamientos = new HashSet<Tratamiento>();
        }
        [Key]
        public int EstadoID { get; set; }
        public string Estado { get; set; }
        [InverseProperty(nameof(Tratamiento.EstadoTratamiento))]
        public virtual ICollection<Tratamiento> Tratamientos { get; set; }
    }
}
