using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E1U2POO.API.Database.Entities
{
    [Table("Planilla")]
    public class PlanillaEntity
    {
        [Key]
        public int Id { get; set; }

        [Column("periodo")]
        [Required(ErrorMessage = "El campo {es requerido}")]
        public string Period { get; set; }

        [Column("fecha_creacion")]
        public DateTime CreateDate { get; set; }
        [Column("fecha_pago")]
        public DateTime PayDate { get; set; }
        [Column("estado")]
        public string State { get; set; }


//        Id(int, clave primaria)
//● Periodo(string, requerido) - Ejemplo: "Marzo 2025"
//● FechaCreacion(DateTime)
//● FechaPago(DateTime)
//● Estado(string) - "Pendiente", "Pagada", "Anulada"
    }
}
