using System;
using AutoMapper;
using Empresa.Ecommerce.Application.DTO;
using Empresa.Ecommerce.Domain.Entity;

namespace Empresa.Ecommerce.Transversal.Maper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();

            //CreateMap<Customers, CustomersDTO>().ReverseMap()
            //    .ForMember(dest => dest.CustomerId, source => source.MapFrom(src => src.CustomerId))
            //    .ForMember(dest => dest.CompanyName, source => source.MapFrom(src => src.CompanyName))
            //    .ForMember(dest => dest.ContactName, source => source.MapFrom(src => src.ContactName))
            //    .ForMember(dest => dest.ContactTitle, source => source.MapFrom(src => src.ContactTitle))
            //    .ForMember(dest => dest.Address, source => source.MapFrom(src => src.Address))
            //    .ForMember(dest => dest.City, source => source.MapFrom(src => src.City))
            //    .ForMember(dest => dest.Region, source => source.MapFrom(src => src.Region))
            //    .ForMember(dest => dest.PostalCode, source => source.MapFrom(src => src.PostalCode))

        }
    }
}
