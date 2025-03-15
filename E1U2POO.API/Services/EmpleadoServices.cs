using AutoMapper;
using E1U2POO.API.Database;
using E1U2POO.API.Database.Entities;
using E1U2POO.API.Dtos;
using E1U2POO.API.Dtos.Empleados;
using E1U2POO.API.Dtos.Planillas;
using E1U2POO.API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E1U2POO.API.Services
{
    public class EmpleadoServices : IEmpleadosServices
    {
        private readonly PlanillaDbContext _context;
        private readonly IMapper _mapper;

        public EmpleadoServices(PlanillaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<EmpleadosDto>>> GetAllAsync()
        {

            var empleadoEntities = await _context.Empleados.ToListAsync();

            var empleadosDtos = _mapper.Map<List<EmpleadosDto>>(empleadoEntities);



            return new ResponseDto<List<EmpleadosDto>>
            { 
                StatusCode = Constants.HttpStatusCode.OK,
                Status = true,
                Message = "Registros Encontrados",
                Data = empleadosDtos
            };

        }

        public async Task<ResponseDto<EmpleadosDto>> GetOneAsync(int id)
        {
            var empleadoEntity = await _context.Empleados.FirstOrDefaultAsync(x => x.Id == id);

            if (empleadoEntity == null)
            {
                return new ResponseDto<EmpleadosDto>
                {
                    StatusCode = Constants.HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = "No se encontro la persona"
                };
            }

            return new ResponseDto<EmpleadosDto>
            {
                StatusCode = Constants.HttpStatusCode.OK,
                Status = true,
                Message = "Registro Encontrado",
                Data = _mapper.Map<EmpleadosDto>(empleadoEntity)
            };
        }

        public async Task<ResponseDto<EmpleadosActionResponseDto>> CreateAsync(EmpleadosCreateDto dto)
        {
            var empleadoEntity = await _context.Empleados.FirstOrDefaultAsync(x => x.Document == dto.Document);

            if (empleadoEntity != null)
            {
                return new ResponseDto<EmpleadosActionResponseDto>
                {
                    StatusCode = Constants.HttpStatusCode.BAD_REQUEST,
                    Status = false,
                    Message = "Ya existe una persona con el mismo Documento"
                };
            }

            var newEmpleado = _mapper.Map<EmpleadoEntity>(dto);

            _context.Empleados.Add(newEmpleado);
            await _context.SaveChangesAsync();

            return new ResponseDto<EmpleadosActionResponseDto>
            {
                StatusCode = Constants.HttpStatusCode.OK,
                Status = true,
                Message = "Registro Creado Correctamente",
                Data = _mapper.Map<EmpleadosActionResponseDto>(newEmpleado)
            };
        }

        public async Task<ResponseDto<EmpleadosActionResponseDto>> EditAsync(EmpleadosEditDto dto, int id)
        {
            var empleadoEntity = await _context.Empleados.FirstOrDefaultAsync(x => x.Id == id);

            if (empleadoEntity == null)
            {
                return new ResponseDto<EmpleadosActionResponseDto>
                {
                    StatusCode = Constants.HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = "No se encontro la persona"
                };
            }

            _mapper.Map<EmpleadosEditDto, EmpleadoEntity>(dto, empleadoEntity);

            _context.Update(empleadoEntity);

            await _context.SaveChangesAsync();
            return new ResponseDto<EmpleadosActionResponseDto>
            {
                StatusCode = Constants.HttpStatusCode.OK,
                Status = true,
                Message = "Registro editado Correctamente",
                Data  = _mapper.Map<EmpleadosActionResponseDto>(empleadoEntity)
            };

        }

        public async Task<ResponseDto<EmpleadosActionResponseDto>> DeleteAsync(int id)
        {
            var empleadoEntity = await _context.Empleados.FirstOrDefaultAsync(x => x.Id == id);

            if (empleadoEntity == null)
            {
                return new ResponseDto<EmpleadosActionResponseDto>
                {
                    StatusCode = Constants.HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = "No se encontro el empleado"
                };
            }

            _context.Remove(empleadoEntity);

            await _context.SaveChangesAsync();

            return new ResponseDto<EmpleadosActionResponseDto>
            {
                StatusCode = Constants.HttpStatusCode.OK,
                Status = true,
                Message = "Registro desactivado correctamente",
                Data = _mapper.Map<EmpleadosActionResponseDto>(empleadoEntity)
            };
        }

        public async Task<ResponseDto<List<EmpleadosActionResponseDto>>> OnlyActives()
        {
            var empleadoEntities = await _context.Empleados.Where(x => x.Active == true).ToListAsync();

            return new ResponseDto<List<EmpleadosActionResponseDto>>
            {
                StatusCode = Constants.HttpStatusCode.OK,
                Status = true,
                Message = "Registro desactivado correctamente",
                Data = _mapper.Map<List<EmpleadosActionResponseDto>>(empleadoEntities)
            };
        }


    }
}
