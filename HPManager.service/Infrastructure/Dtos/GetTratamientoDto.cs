namespace HPManager.service.Infrastructure.Dtos
{
    public class GetTratamientoDto : UpdateTratamientoDto
    {
        public int EstadoID { get; set; }
        public string NombreEstado { get; set; }
    }
}
