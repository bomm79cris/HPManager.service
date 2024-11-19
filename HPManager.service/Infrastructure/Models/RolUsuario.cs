using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HPManager.service.Infrastructure.Models
{
    [Table("RolesUsuarios")]
    public class RolUsuario
    {
        public RolUsuario() { 
        }
        [Key]
        public int RolId { get; set; }
        public string TipoUsuario { get; set; }
      
    }
}
