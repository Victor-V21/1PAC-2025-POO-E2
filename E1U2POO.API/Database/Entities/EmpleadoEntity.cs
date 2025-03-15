using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E1U2POO.API.Database.Entities
{
    [Table("Empleados")]
    public class EmpleadoEntity
    {
        [Key]
        public int Id { get; set; }

        [Column("name")]
        [Required(ErrorMessage ="El campo {es requerido}")]
        public string Name { get; set; }

        [Column("apellidos")]
        [Required(ErrorMessage = "El campo {es requerido}")]
        public string LastNames { get; set; }

        [Column("documento")]
        [Required(ErrorMessage = "El campo {es requerido}")]
        public string Document { get; set; }

        [Column("fecha_contratacio")]
        public DateTime DateContrat { get; set; }

        [Column("departamento")]
        public string Departament {  get; set; }

        [Column("puesto_de_trabajo")]
        public string WorkState { get; set; }

        [Column("salario_base")]
        public decimal SalarioBase { get; set; }

        [Column("activo")]
        public bool Active { get; set; }

//        Id(int, clave primaria)
//● Nombre(string, requerido)
//● Apellido(string, requerido)
//● Documento(string, requerido, único)
//● FechaContratacion(DateTime)
//● Departamento(string)
//● PuestoTrabajo(string)
//● SalarioBase(decimal)
//● Activo(bool)
    }
}
