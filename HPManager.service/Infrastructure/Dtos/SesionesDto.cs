namespace HPManager.service.Infrastructure.Dtos
{

    public class SesionesDto
    {
        public int PsicologoID { get; set; }
        public int EstudianteID { get; set; }
        public DateTime FechaHora { get; set; }
        public string Descripcion { get; set; }
        public string ObjetivoAlcanzado { get; set; }
        public string AspectosAMejorar { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}