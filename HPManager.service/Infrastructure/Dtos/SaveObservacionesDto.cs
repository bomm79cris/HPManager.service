namespace HPManager.service.Infrastructure.Dtos
{
    public class SaveObservacionesDto
    {
        public int PsicologoID { get; set; }
        public int EstudianteID { get; set; }
        public DateTime Fecha {  get; set; }
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }
    }
}
