using E1U2POO.API.Dtos.DetallePlanilla;
using E1U2POO.API.Dtos;

namespace E1U2POO.API.Services.Interfaces
{
    public interface IDetallePlanillaServices
    {
        Task<ResponseDto<DetallePlanillaDto>> CreateAsync(DetallePlanillaCreateDto dto);
    }
}
