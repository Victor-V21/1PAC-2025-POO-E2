using E1U2POO.API.Database;
using E1U2POO.API.Dtos.Empleados;
using E1U2POO.API.Dtos;
using E1U2POO.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using E1U2POO.API.Dtos.Planillas;
using E1U2POO.API.Database.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace E1U2POO.API.Services
{
    public class PlanillaServices : IPlanillaServices
    {
        private readonly PlanillaDbContext _context;
        private readonly IMapper _mapper;

        public PlanillaServices(PlanillaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<PlanillaDto>>> GetAllAsync()
        {

            var planillaEntities = await _context.Planilla.ToListAsync();

            var planillaDtos = _mapper.Map<List<PlanillaDto>>(planillaEntities);

            return new ResponseDto<List<PlanillaDto>>
            {
                StatusCode = Constants.HttpStatusCode.OK,
                Status = true,
                Message = "Registros Encontrados",
                Data = planillaDtos
            };
        }

        public async Task<ResponseDto<PlanillaDto>> GetOneAsync(int id)
        {
            var planillaEntity = await _context.Planilla.FirstOrDefaultAsync(x => x.Id == id);

            if (planillaEntity == null)
            {
                return new ResponseDto<PlanillaDto>
                {
                    StatusCode = Constants.HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = "No se encontro la planilla"
                };
            }

            return new ResponseDto<PlanillaDto>
            {
                StatusCode = Constants.HttpStatusCode.OK,
                Status = true,
                Message = "Registro Encontrado",
                Data = _mapper.Map<PlanillaDto>(planillaEntity)
            };
        }

        public async Task<ResponseDto<PlanillaActionResponseDto>> CreateAsync(PlanillaCreateDto dto)
        {

            var newPlanilla = _mapper.Map<PlanillaEntity>(dto);

            _context.Planilla.Add(newPlanilla);
            await _context.SaveChangesAsync();

            return new ResponseDto<PlanillaActionResponseDto>
            {
                StatusCode = Constants.HttpStatusCode.OK,
                Status = true,
                Message = "Registro Creado Correctamente",
                Data = _mapper.Map<PlanillaActionResponseDto>(newPlanilla)
            };
        }

        public async Task<ResponseDto<PlanillaActionResponseDto>> EditAsync(PlanillaEditDto dto, int id)
        {
            var planillaEntity = await _context.Planilla.FirstOrDefaultAsync(x => x.Id == id);

            if (planillaEntity == null)
            {
                return new ResponseDto<PlanillaActionResponseDto>
                {
                    StatusCode = Constants.HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = "No se encontro la persona"
                };
            }

            _mapper.Map<PlanillaEditDto, PlanillaEntity>(dto, planillaEntity);

            _context.Planilla.Update(planillaEntity);

            await _context.SaveChangesAsync();

            return new ResponseDto<PlanillaActionResponseDto>
            {
                StatusCode = Constants.HttpStatusCode.OK,
                Status = true,
                Message = "Registro editado Correctamente",
                Data = _mapper.Map<PlanillaActionResponseDto>(planillaEntity)
            };

        }
        public async Task<ResponseDto<PlanillaActionResponseDto>> DeleteAsync(int id)
        {
            var planillaEntity = await _context.Planilla.FirstOrDefaultAsync(x => x.Id == id);

            if (planillaEntity == null)
            {
                return new ResponseDto<PlanillaActionResponseDto>
                {
                    StatusCode = Constants.HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = "No se encontro la planilla"
                };
            }

            _context.Remove(planillaEntity);

            await _context.SaveChangesAsync();

            return new ResponseDto<PlanillaActionResponseDto>
            {
                StatusCode = Constants.HttpStatusCode.OK,
                Status = true,
                Message = "Registro eliminado correctamente",
                Data = _mapper.Map<PlanillaActionResponseDto>(planillaEntity)
            };
        }

        public async Task<ResponseDto<List<PlanillaActionResponseDto>>> GetByPeriod(string period)
        {
            var planillaEntity = await _context.Planilla.Where(x => x.Period == period).ToListAsync();

            return new ResponseDto<List<PlanillaActionResponseDto>>
            {
                StatusCode = Constants.HttpStatusCode.OK,
                Status = true,
                Message = "Registros Encontrados Correctamente",
                Data = _mapper.Map<List<PlanillaActionResponseDto>>(planillaEntity)
            };
        }

        public async Task<ResponseDto<PlanillaActionResponseDto>> EditState(int id, string state)
        {
            var planillaEntity = await _context.Planilla.FirstOrDefaultAsync(x => x.Id == id);

            if (planillaEntity == null)
            {
                return new ResponseDto<PlanillaActionResponseDto>
                {
                    StatusCode = Constants.HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = "No se encontro la planilla"
                };
            }

            planillaEntity.State = state;
            _context.Planilla.Update(planillaEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<PlanillaActionResponseDto>
            {
                StatusCode = Constants.HttpStatusCode.OK,
                Status = true,
                Message = "Registro modificado correctamente",
                Data = _mapper.Map<PlanillaActionResponseDto>(planillaEntity)
            };
        }
    }
}
