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

            CreateMap<Downtime, DowntimeDto>()
            .ForMember(dest => dest.WorkOrderNumber, opt => opt.MapFrom(src => src.WorkOrder.OrderNumber))
            .ForMember(dest => dest.DowntimeReasonDescription, opt => opt.MapFrom(src => src.DowntimeReason.Description));

            CreateMap<CreateDowntimeDto, Downtime>();

            CreateMap<Defect, DefectDto>()
            .ForMember(dest => dest.WorkOrderNumber, opt => opt.MapFrom(src => src.WorkOrder.OrderNumber))
            .ForMember(dest => dest.DefectTypeDescription, opt => opt.MapFrom(src => src.DefectType.Description));

            CreateMap<CreateDefectDto, Defect>();
        }
    }
}
