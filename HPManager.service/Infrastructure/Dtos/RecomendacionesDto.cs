namespace HPManager.service.Infrastructure.Dtos
{
	public class RecomendacionesDto
	{
		public int DocenteID { get; set; }
		public string nombreDocente { get; set; }
		public int EstudianteId { get; set; }
		public string nombreEstudiante { get; set; }
		public int PsicologoId { get; set; }
		public string nombrePsicologo { get; set; }
		public DateTime Fecha { get; set; }
		public string Recomendacion { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}