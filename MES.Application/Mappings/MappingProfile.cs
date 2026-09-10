using AutoMapper;
using MES.Application.DTOs;
using MES.Domain.Entities;

namespace MES.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() // sve konfiguracije mapiranja idu u konstruktor.
        {
            CreateMap<Product, ProductDto>(); // kad vracas podatke klijentu
            CreateMap<CreateProductDto, Product>(); // kad klijent salje data za kreiranje

            CreateMap<Machine, MachineDto>();
            CreateMap<CreateMachineDto, Machine>();

            CreateMap<DowntimeReason, DowntimeReasonDto>();
            CreateMap<CreateDowntimeReasonDto, DowntimeReason>();

            CreateMap<DefectType, DefectTypeDto>();
            CreateMap<CreateDefectTypeDto,  DefectType>();

            CreateMap<Shift, ShiftDto>();
            CreateMap<CreateShiftDto, Shift>();

            CreateMap<WorkOrder, WorkOrderDto>()
            .ForMember(dest => dest.AssignedUserName, opt => opt.MapFrom(src => src.AssignedUser.FullName));
        }
    }
}
