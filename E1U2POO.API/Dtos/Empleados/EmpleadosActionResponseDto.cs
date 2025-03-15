using System.ComponentModel.DataAnnotations;

namespace E1U2POO.API.Dtos.Empleados
{
    public class EmpleadosActionResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastNames { get; set; }
        public string Document { get; set; }
    }
}
