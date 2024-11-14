namespace HPManager.service.Infrastructure.Dtos
{
    public class SaveRecomendacionesDto
    {
        public int DocenteID { get; set; }
        public int PsicologoID { get; set; }
        public int EstudianteID { get; set; }
        public DateTime Fecha { get; set; }
        public string Recomendacion { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}