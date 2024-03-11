using Application.Features.ShopSellers.Commands.Create;
using Application.Features.ShopSellers.Commands.Delete;
using Application.Features.ShopSellers.Commands.Update;
using Application.Features.ShopSellers.Queries.GetById;
using Application.Features.ShopSellers.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ShopSellers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ShopSeller, CreateShopSellerCommand>().ReverseMap();
        CreateMap<ShopSeller, CreatedShopSellerResponse>().ReverseMap();
        CreateMap<ShopSeller, UpdateShopSellerCommand>().ReverseMap();
        CreateMap<ShopSeller, UpdatedShopSellerResponse>().ReverseMap();
        CreateMap<ShopSeller, DeleteShopSellerCommand>().ReverseMap();
        CreateMap<ShopSeller, DeletedShopSellerResponse>().ReverseMap();
        CreateMap<ShopSeller, GetByIdShopSellerResponse>().ReverseMap();
        CreateMap<ShopSeller, GetListShopSellerListItemDto>().ReverseMap();
        CreateMap<IPaginate<ShopSeller>, GetListResponse<GetListShopSellerListItemDto>>().ReverseMap();
    }
}