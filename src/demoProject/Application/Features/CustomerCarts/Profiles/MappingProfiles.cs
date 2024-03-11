using Application.Features.CustomerCarts.Commands.Create;
using Application.Features.CustomerCarts.Commands.Delete;
using Application.Features.CustomerCarts.Commands.Update;
using Application.Features.CustomerCarts.Queries.GetById;
using Application.Features.CustomerCarts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CustomerCarts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CustomerCart, CreateCustomerCartCommand>().ReverseMap();
        CreateMap<CustomerCart, CreatedCustomerCartResponse>().ReverseMap();
        CreateMap<CustomerCart, UpdateCustomerCartCommand>().ReverseMap();
        CreateMap<CustomerCart, UpdatedCustomerCartResponse>().ReverseMap();
        CreateMap<CustomerCart, DeleteCustomerCartCommand>().ReverseMap();
        CreateMap<CustomerCart, DeletedCustomerCartResponse>().ReverseMap();
        CreateMap<CustomerCart, GetByIdCustomerCartResponse>().ReverseMap();
        CreateMap<CustomerCart, GetListCustomerCartListItemDto>().ReverseMap();
        CreateMap<IPaginate<CustomerCart>, GetListResponse<GetListCustomerCartListItemDto>>().ReverseMap();
    }
}