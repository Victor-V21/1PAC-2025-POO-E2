﻿namespace E1U2POO.API.Dtos.Planillas
{
    public class PlanillaCreateDto
    {
        public string Period { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PayDate { get; set; }
        public string State { get; set; }
    }
}
