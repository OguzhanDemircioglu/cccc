﻿using AutoMapper;
using server.Application.Features.Customers.CreateCustomer;
using server.Application.Features.Customers.UpdateCustomer;
using server.Application.Features.Depots.CreateDepot;
using server.Application.Features.Depots.UpdateDepot;
using server.Application.Features.Invoices.CreateInvoice;
using server.Application.Features.Orders.CreateOrder;
using server.Application.Features.Orders.UpdateOrder;
using server.Application.Features.Products.CreateProduct;
using server.Application.Features.Products.UpdateProduct;
using server.Application.Features.RecipeDetails.CreateRecipeDetail;
using server.Application.Features.RecipeDetails.UpdateRecipeDetail;
using server.Domain.Entities;
using server.Domain.Enums;

namespace server.Application.Mapping;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCustomerCommand, Customer>();
        CreateMap<UpdateCustomerCommand, Customer>();

        CreateMap<CreateDepotCommand, Depot>();
        CreateMap<UpdateDepotCommand, Depot>();

        CreateMap<CreateProductCommand, Product>()
            .ForMember(m => m.Type, opt => 
                opt.MapFrom(x => ProductTypeEnum.FromValue(x.TypeValue)));

        CreateMap<UpdateProductCommand, Product>()
            .ForMember(m => m.Type, opt => 
                opt.MapFrom(x => ProductTypeEnum.FromValue(x.TypeValue)));

        CreateMap<CreateRecipeDetailCommand, RecipeDetail>();
        CreateMap<UpdateRecipeDetailCommand, RecipeDetail>();

        CreateMap<CreateOrderCommand, Order>()
            .ForMember(m => m.Details,
                options => options
                    .MapFrom(p => p.Details
                        .Select(s => new OrderDetail
                            { Price = s.Price, ProductId = s.ProductId, Quantity = s.Quantity })));

        CreateMap<CreateInvoiceCommand, Invoice>()
            .ForMember(m => m.Type, options =>
                options.MapFrom(p => InvoiceTypeEnum.FromValue(p.InvoiceType)))
            .ForMember(m => m.Details,
                options => options
                    .MapFrom(p => p.Details
                        .Select(s => new InvoiceDetail()
                            { Price = s.Price, ProductId = s.ProductId, Quantity = s.Quantity })));

        CreateMap<UpdateOrderCommand, Order>()
            .ForMember(member =>
                    member.Details,
                options => options.Ignore());
    }
}