using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HPManager.service.Infrastructure.Models
{
    [Table("RolesUsuarios")]
    public class RolUsuario
    {
        public RolUsuario() { 
            Usuarios = new HashSet<Usuario>();
        }
        [Key]
        public int RolId { get; set; }
        public string TipoUsuario { get; set; }
        [InverseProperty(nameof(Usuario.Rol))]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
