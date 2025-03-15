using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E1U2POO.API.Dtos.Planillas
{
    public class PlanillaDto
    {
        
        public int Id { get; set; }

        public string Period { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime PayDate { get; set; }
        public string State { get; set; }

    }
}
