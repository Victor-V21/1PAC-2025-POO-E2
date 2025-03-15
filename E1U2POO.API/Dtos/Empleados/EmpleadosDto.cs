using System.ComponentModel.DataAnnotations;

namespace E1U2POO.API.Dtos.Empleados
{
    public class EmpleadosDto
    {
        public string Name { get; set; }

        public string LastNames { get; set; }

        public string Document { get; set; }

        public DateTime DateContrat { get; set; }

        public string Departament { get; set; }

        public string WorkState { get; set; }

        public decimal SalarioBase { get; set; }

        public bool Active { get; set; }
    }
}
