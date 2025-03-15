using E1U2POO.API.Dtos;
using E1U2POO.API.Dtos.DetallePlanilla;
using E1U2POO.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E1U2POO.API.Controllers
{
    [ApiController]
    [Route("api/detallesplanillas")]
    public class DetallePlanillasController : ControllerBase
    {
        private readonly IDetallePlanillaServices _services;

        public DetallePlanillasController(IDetallePlanillaServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<DetallePlanillaDto>>> Create([FromBody] DetallePlanillaCreateDto dto)
        {
            var response = await _services.CreateAsync(dto);

            return StatusCode(response.StatusCode, response);
        }
    }
}
