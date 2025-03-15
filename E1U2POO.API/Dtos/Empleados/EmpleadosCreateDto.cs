using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E1U2POO.API.Dtos.Empleados
{
    public class EmpleadosCreateDto
    {
        //public int Id { get; set; }

        [Display(Name = "name")]
        [Required(ErrorMessage = "El campo {es requerido}")]
        public string Name { get; set; }

        [Display(Name = "apellidos")]
        [Required(ErrorMessage = "El campo {es requerido}")]
        public string LastNames { get; set; }

        [Display (Name = "documento")]
        [Required(ErrorMessage = "El campo {es requerido}")]
        public string Document { get; set; }

        [Display(Name = "fecha_contratacio")]
        public DateTime DateContrat { get; set; }

        [Display(Name = "departamento")]
        public string Departament { get; set; }

        [Display(Name = "puesto_de_trabajo")]
        public string WorkState { get; set; }

        [Display(Name = "salario_base")]
        public decimal SalarioBase { get; set; }

        [Display(Name = "activo")]
        public bool Active { get; set; }
    }
}
