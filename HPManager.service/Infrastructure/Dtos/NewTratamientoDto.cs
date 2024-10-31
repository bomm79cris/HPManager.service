namespace HPManager.service.Infrastructure.Dtos
{
    public class NewTratamientoDto : UpdateTratamientoDto
    {
        public int EstudianteID { get; set; }
        public int PsicologoID { get; set; }
    }
}
