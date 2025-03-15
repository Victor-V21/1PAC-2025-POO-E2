using E1U2POO.API.Dtos;
using E1U2POO.API.Dtos.Empleados;
using E1U2POO.API.Dtos.Planillas;
using E1U2POO.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E1U2POO.API.Controllers
{
    [ApiController]
    [Route("api/planillas")]
    public class PlanillasController : ControllerBase
    {

        private readonly IPlanillaServices _services;
        public PlanillasController(IPlanillaServices services)
        {
            _services = services;
        }

        [HttpGet]

        public async Task<ActionResult<ResponseDto<List<PlanillaDto>>>> GetAll()
        {
            var response = await _services.GetAllAsync();

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<PlanillaDto>>> GetOne(int id)
        {
            var response = await _services.GetOneAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<PlanillaDto>>> Post(PlanillaCreateDto dto)
        {
            var response = await _services.CreateAsync(dto);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<PlanillaActionResponseDto>>> Edit([FromBody] PlanillaEditDto dto, int id)
        {
            var response = await _services.EditAsync(dto, id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<PlanillaActionResponseDto>>> Delete(int id)
        {
            var response = await _services.DeleteAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("periodo/{period}")]
        public async Task<ActionResult<ResponseDto<PlanillaActionResponseDto>>> GetByPeriod(string period)
        {
            var response = await _services.GetByPeriod(period);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}/{state}")]

        public async Task<ActionResult<ResponseDto<PlanillaActionResponseDto>>> EditState(int id, string state)
        {
            var response = await _services.EditState(id, state);

            return StatusCode(response.StatusCode, response);
        }

    }
}
