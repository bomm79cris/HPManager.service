namespace HPManager.service.Infrastructure.Dtos

{
    public class ComportamientoDto
    {
        public int ComportamientoID { get; set; }
        public int DocenteID { get; set; }
        public string DocenteFullName { get; set; } = default!;
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public bool SoyElCreador { get; set; }
    }
}