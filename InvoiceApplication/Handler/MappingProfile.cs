using InvoiceApplication.DTOs;
using AutoMapper;
using InvoiceApplication.Models;

namespace InvoiceApplication.Handler
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();

            CreateMap<Customer, CustomerDto>();

            CreateMap<Product, ProductDto>()
                .ForMember(dest =>
                dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<ProductDto, Product>();

            CreateMap<InvoiceItemDto, InvoiceItem>();
        }
    }
}