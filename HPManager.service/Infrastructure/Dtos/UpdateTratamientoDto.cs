namespace HPManager.service.Infrastructure.Dtos
{
    public class UpdateTratamientoDto
    {
        public string Titulo { get; set; }
        public string Description { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}
