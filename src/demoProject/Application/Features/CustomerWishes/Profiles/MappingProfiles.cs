using Application.Features.CustomerWishes.Commands.Create;
using Application.Features.CustomerWishes.Commands.Delete;
using Application.Features.CustomerWishes.Commands.Update;
using Application.Features.CustomerWishes.Queries.GetById;
using Application.Features.CustomerWishes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CustomerWishes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CustomerWish, CreateCustomerWishCommand>().ReverseMap();
        CreateMap<CustomerWish, CreatedCustomerWishResponse>().ReverseMap();
        CreateMap<CustomerWish, UpdateCustomerWishCommand>().ReverseMap();
        CreateMap<CustomerWish, UpdatedCustomerWishResponse>().ReverseMap();
        CreateMap<CustomerWish, DeleteCustomerWishCommand>().ReverseMap();
        CreateMap<CustomerWish, DeletedCustomerWishResponse>().ReverseMap();
        CreateMap<CustomerWish, GetByIdCustomerWishResponse>().ReverseMap();
        CreateMap<CustomerWish, GetListCustomerWishListItemDto>().ReverseMap();
        CreateMap<IPaginate<CustomerWish>, GetListResponse<GetListCustomerWishListItemDto>>().ReverseMap();
    }
}