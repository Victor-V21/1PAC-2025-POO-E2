using System.ComponentModel.DataAnnotations.Schema;

namespace E1U2POO.API.Database.Entities
{
    [Table("Detalle_Planilla")]
    public class DetallePlanillaEntity
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("planilla_id")]
        public int PlanillaId { get; set; } // llave foranea
        [Column("empleado_id")]
        public int EmpleadoId { get; set; } // llave foranea
        [Column("salario_base")]
        public decimal SalarioBase { get; set; }
        [Column("horas_extra")]
        public decimal ExtraHours { get; set;}
        [Column("monto_horas_extra")]
        public decimal MountExtraHours { get; set;}
        [Column("bonificacion")]
        public decimal Bonification  { get; set;}
        [Column("salario_neto")]
        public decimal SalarioNeto { get; set;}
        [Column("comentarios")]
        public string Commit { get; set;}

        [ForeignKey(nameof(PlanillaId))]
        public virtual PlanillaEntity Planilla { get; set; }

        [ForeignKey(nameof(EmpleadoId))]
        public virtual EmpleadoEntity Empleado { get; set; }




        //        Id(int, clave primaria)
        //● PlanillaId(int, clave foránea)
        //● EmpleadoId(int, clave foránea)
        //● SalarioBase(decimal)
        //● HorasExtra(decimal)
        //● MontoHorasExtra(decimal)
        //● Bonificaciones(decimal)
        //● Deducciones(decimal)
        //● SalarioNeto(decimal)
        //● Comentarios(string)
    }
}
