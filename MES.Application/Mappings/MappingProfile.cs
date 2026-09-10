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
        }
    }
}
