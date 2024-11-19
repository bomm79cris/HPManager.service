namespace HPManager.service.Infrastructure.Dtos
{
    public class CitasDto
    {
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; }
        public int PsicologoID { get; set; }
        public int EstudianteID { get; set; }
        public int CreateBy { get; set; }
        public string? Descripcion { get; set; }
        public bool DebeIrPadre { get; set; }
    }
}
