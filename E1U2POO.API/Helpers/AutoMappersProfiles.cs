using AutoMapper;
using E1U2POO.API.Database.Entities;
using E1U2POO.API.Dtos.Empleados;

namespace E1U2POO.API.Helpers
{
    public class AutoMappersProfiles : Profile
    {
        public AutoMappersProfiles()
        {
            CreateMap<EmpleadoEntity, EmpleadosDto>(); // Para pedir un registro 

            CreateMap<EmpleadosCreateDto, EmpleadoEntity>(); // Para crear

            CreateMap<EmpleadoEntity, EmpleadosActionResponseDto>();
        }
    }
}
