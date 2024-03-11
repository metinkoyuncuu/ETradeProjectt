using Application.Features.CustomerOrders.Commands.Create;
using Application.Features.CustomerOrders.Commands.Delete;
using Application.Features.CustomerOrders.Commands.Update;
using Application.Features.CustomerOrders.Queries.GetById;
using Application.Features.CustomerOrders.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CustomerOrders.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CustomerOrder, CreateCustomerOrderCommand>().ReverseMap();
        CreateMap<CustomerOrder, CreatedCustomerOrderResponse>().ReverseMap();
        CreateMap<CustomerOrder, UpdateCustomerOrderCommand>().ReverseMap();
        CreateMap<CustomerOrder, UpdatedCustomerOrderResponse>().ReverseMap();
        CreateMap<CustomerOrder, DeleteCustomerOrderCommand>().ReverseMap();
        CreateMap<CustomerOrder, DeletedCustomerOrderResponse>().ReverseMap();
        CreateMap<CustomerOrder, GetByIdCustomerOrderResponse>().ReverseMap();
        CreateMap<CustomerOrder, GetListCustomerOrderListItemDto>().ReverseMap();
        CreateMap<IPaginate<CustomerOrder>, GetListResponse<GetListCustomerOrderListItemDto>>().ReverseMap();
    }
}