using AutoMapper;
using E1U2POO.API.Database;
using E1U2POO.API.Database.Entities;
using E1U2POO.API.Dtos;
using E1U2POO.API.Dtos.DetallePlanilla;
using E1U2POO.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E1U2POO.API.Services
{
    public class DetallePlanillaServices : IDetallePlanillaServices
    {
        private readonly PlanillaDbContext _context;
        private readonly IMapper _mapper;
        public DetallePlanillaServices(PlanillaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // Crear una nueva planilla

        public async Task<ResponseDto<DetallePlanillaDto>> CreateAsync(DetallePlanillaCreateDto dto)
        {
            var planillaEntity = await _context.Planilla.FirstOrDefaultAsync(x => x.Id == dto.PlanillaId);
            var empleadoEntity = await _context.Empleados.FirstOrDefaultAsync(x => x.Id == dto.EmpleadoId);

            
            if (planillaEntity == null || empleadoEntity == null)
            {
                return new ResponseDto<DetallePlanillaDto>
                {
                    StatusCode = Constants.HttpStatusCode.BAD_REQUEST,
                    Status = false,
                    Message = "No existe la planilla o el empleado",
                };
            }

            if(dto.SalarioBase < 0 || dto.ExtraHours < 0 || dto.MountExtraHours < 0 || dto.Bonification < 0)
            {
                return new ResponseDto<DetallePlanillaDto>
                {
                    StatusCode = Constants.HttpStatusCode.BAD_REQUEST,
                    Status = false,
                    Message = "No existe la planilla o el empleado",
                };
            }

            var newDetallePlanilla = _mapper.Map<DetallePlanillaEntity>(dto);

            newDetallePlanilla.SalarioNeto = (dto.ExtraHours * dto.MountExtraHours) + dto.SalarioBase + dto.Bonification;

            _context.Detalle.Add(newDetallePlanilla);
            await _context.SaveChangesAsync();

            return new ResponseDto<DetallePlanillaDto>
            {
                StatusCode = Constants.HttpStatusCode.OK,
                Status = true,
                Message = "Registro Creado correctamente",
            };

        }
    }
}
