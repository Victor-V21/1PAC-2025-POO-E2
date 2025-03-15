using E1U2POO.API.Dtos;
using E1U2POO.API.Dtos.Empleados;
using E1U2POO.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E1U2POO.API.Controllers
{
    [ApiController]
    [Route("/api/empleados")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadosServices _services;
        public EmpleadosController(IEmpleadosServices services)
        {
            _services = services;
        }

        [HttpGet]

        public async Task<ActionResult<ResponseDto<List<EmpleadosDto>>>> GetAll()
        {
            var response = await _services.GetAllAsync();

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<EmpleadosDto>>> GetOne(int id)
        {
            var response = await _services.GetOneAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<EmpleadosActionResponseDto>>> Create([FromBody] EmpleadosCreateDto dto)
        {
            var response = await _services.CreateAsync(dto);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ResponseDto<EmpleadosActionResponseDto>>> Delete(int id)
        {
            var response = await _services.DeleteAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<ResponseDto<EmpleadosActionResponseDto>>> Put([FromBody] EmpleadosEditDto dto, int id)
        {
            var response = await _services.EditAsync(dto, id);

            return StatusCode(response.StatusCode, response);
        }
    }
}
