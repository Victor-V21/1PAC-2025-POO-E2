using E1U2POO.API.Dtos.Planillas;
using E1U2POO.API.Dtos;

namespace E1U2POO.API.Services.Interfaces
{
    public interface IPlanillaServices
    {
        Task<ResponseDto<List<PlanillaDto>>> GetAllAsync(); //
        Task<ResponseDto<PlanillaDto>> GetOneAsync(int id); //
        Task<ResponseDto<PlanillaActionResponseDto>> CreateAsync(PlanillaCreateDto dto); //
        Task<ResponseDto<PlanillaActionResponseDto>> EditAsync(PlanillaEditDto dto, int id); //
        Task<ResponseDto<PlanillaActionResponseDto>> DeleteAsync(int id); //
        Task<ResponseDto<List<PlanillaActionResponseDto>>> GetByPeriod(string period); //
        Task<ResponseDto<PlanillaActionResponseDto>> EditState(int id, string state);

    }
}
