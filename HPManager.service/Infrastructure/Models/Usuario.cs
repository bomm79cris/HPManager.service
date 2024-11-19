﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HPManager.service.Infrastructure.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
     
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Genero { get; set; }
        public int Edad {  get; set; }
        public int RolID { get; set; }
        public DateTime Created_at { get; set; }
        [ForeignKey(nameof(RolID))]
        public virtual RolUsuario Rol { get; set; }
        [InverseProperty(nameof(Docente.Usuario))]
        public virtual Docente Docente { get; set; }
        [InverseProperty(nameof(Estudiante.Usuario))]
        public virtual Estudiante Estudiante { get; set; }
        [InverseProperty(nameof(Psicologo.Usuario))]
        public virtual Psicologo Psicologos { get; set; }
        [InverseProperty(nameof(PadreDeFamilia.Usuario))]
        public virtual PadreDeFamilia PadreDeFamilia { get; set; }
        [InverseProperty(nameof(Cita.Usuario))]
        public virtual ICollection<Cita> CitasCreadas { get; set; }

    }
}
