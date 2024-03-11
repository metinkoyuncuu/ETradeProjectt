using Application.Features.OrderProducts.Commands.Create;
using Application.Features.OrderProducts.Commands.Delete;
using Application.Features.OrderProducts.Commands.Update;
using Application.Features.OrderProducts.Queries.GetById;
using Application.Features.OrderProducts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.OrderProducts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<OrderProduct, CreateOrderProductCommand>().ReverseMap();
        CreateMap<OrderProduct, CreatedOrderProductResponse>().ReverseMap();
        CreateMap<OrderProduct, UpdateOrderProductCommand>().ReverseMap();
        CreateMap<OrderProduct, UpdatedOrderProductResponse>().ReverseMap();
        CreateMap<OrderProduct, DeleteOrderProductCommand>().ReverseMap();
        CreateMap<OrderProduct, DeletedOrderProductResponse>().ReverseMap();
        CreateMap<OrderProduct, GetByIdOrderProductResponse>().ReverseMap();
        CreateMap<OrderProduct, GetListOrderProductListItemDto>().ReverseMap();
        CreateMap<IPaginate<OrderProduct>, GetListResponse<GetListOrderProductListItemDto>>().ReverseMap();
    }
}