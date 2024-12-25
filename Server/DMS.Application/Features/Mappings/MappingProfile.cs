using AutoMapper;
using DMS.Application.Features.DTOs;
using DMS.Domain.Entities;

namespace DMS.Application.Features.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Product mappings
        CreateMap<Product, ProductDto>().ReverseMap();

        // Customer mappings
        CreateMap<Customer, CustomerDto>().ReverseMap();

        // Invoice and line item mappings
        CreateMap<Invoice, InvoiceDto>().ReverseMap();
        CreateMap<InvoiceLineItem, InvoiceLineItemDto>().ReverseMap();

        // Discount mappings
        CreateMap<Discount, DiscountDto>().ReverseMap();

        // Truck and loaded product mappings
        CreateMap<Truck, TruckDto>().ReverseMap();
        CreateMap<LoadedProduct, LoadedProductDto>().ReverseMap();

        // Payment mappings
        CreateMap<Payment, PaymentDto>().ReverseMap();

        // Inventory mappings
        CreateMap<Inventory, InventoryDto>().ReverseMap();
    }
}

