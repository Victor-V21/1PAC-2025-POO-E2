using E1U2POO.API.Dtos.Empleados;
using E1U2POO.API.Dtos;

namespace E1U2POO.API.Services.Interfaces
{
    public interface IEmpleadosServices
    {
        Task<ResponseDto<List<EmpleadosDto>>> GetAllAsync();
        Task<ResponseDto<EmpleadosDto>> GetOneAsync(int id);
        Task<ResponseDto<EmpleadosActionResponseDto>> CreateAsync(EmpleadosCreateDto dto);
        Task<ResponseDto<EmpleadosActionResponseDto>> EditAsync(EmpleadosEditDto dto, int id);
        Task<ResponseDto<EmpleadosActionResponseDto>> DeleteAsync(int id);
        Task<ResponseDto<List<EmpleadosActionResponseDto>>> OnlyActives();
    }
}
