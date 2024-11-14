namespace HPManager.service.Infrastructure.Dtos

{
    public class SaveComportamientoDto
    {
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public DateTime CreatedAt { get; set; }
        public int DocenteID { get; set; }
        public int EstudianteID { get; set; }
    }
}