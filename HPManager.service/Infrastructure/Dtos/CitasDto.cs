namespace HPManager.service.Infrastructure.Dtos
{
    public class CitasDto
    {
        public int CitaID { get; set; }
        public DateTime FechaHora { get; set; }
        public string NombreEstado { get; set; }
        public int EstadoID { get; set; }
        public string Motivo { get; set; }
        public DateTime CreatedAt { get; set; }
        public string NombrePsicologo { get; set; }
        public bool DebeIrPadre { get; set; }
    }
}
