using Application.Features.ShopProducts.Commands.Create;
using Application.Features.ShopProducts.Commands.Delete;
using Application.Features.ShopProducts.Commands.Update;
using Application.Features.ShopProducts.Queries.GetById;
using Application.Features.ShopProducts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ShopProducts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ShopProduct, CreateShopProductCommand>().ReverseMap();
        CreateMap<ShopProduct, CreatedShopProductResponse>().ReverseMap();
        CreateMap<ShopProduct, UpdateShopProductCommand>().ReverseMap();
        CreateMap<ShopProduct, UpdatedShopProductResponse>().ReverseMap();
        CreateMap<ShopProduct, DeleteShopProductCommand>().ReverseMap();
        CreateMap<ShopProduct, DeletedShopProductResponse>().ReverseMap();
        CreateMap<ShopProduct, GetByIdShopProductResponse>().ReverseMap();
        CreateMap<ShopProduct, GetListShopProductListItemDto>().ReverseMap();
        CreateMap<IPaginate<ShopProduct>, GetListResponse<GetListShopProductListItemDto>>().ReverseMap();
    }
}