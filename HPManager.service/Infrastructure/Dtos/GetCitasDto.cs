namespace HPManager.service.Infrastructure.Dtos
{
    public class GetCitasDto
    {
        public int EstudianteId { get; set; }
        public string NombreEstudiante { get; set; }
        public int PsicologoID { get; set; }
        public string NombrePsicologo {  get; set; }
        public DateTime FechaHora { get; set; }
        public int EstadoID { get; set; }
        public string NombreEstado { get; set; }
        public string Motivo { get; set; }
        public string? Descripcion { get; set; }
        public string SolicitadoPor { get; set; }
        public bool DebeIrPadre { get; set; }
        public bool EsCancelable { get; set; }
    }
}
