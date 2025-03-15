using System.ComponentModel.DataAnnotations.Schema;

namespace E1U2POO.API.Dtos.DetallePlanilla
{
    public class DetallePlanillaCreateDto
    {
        public int Id { get; set; }
        public int PlanillaId { get; set; }
        public int EmpleadoId { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal ExtraHours { get; set; }
        public decimal MountExtraHours { get; set; }
        public decimal Bonification { get; set; }
        public string Commit { get; set; }
    }
}
