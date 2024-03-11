using Application.Features.ShopImages.Commands.Create;
using Application.Features.ShopImages.Commands.Delete;
using Application.Features.ShopImages.Commands.Update;
using Application.Features.ShopImages.Queries.GetById;
using Application.Features.ShopImages.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ShopImages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ShopImage, CreateShopImageCommand>().ReverseMap();
        CreateMap<ShopImage, CreatedShopImageResponse>().ReverseMap();
        CreateMap<ShopImage, UpdateShopImageCommand>().ReverseMap();
        CreateMap<ShopImage, UpdatedShopImageResponse>().ReverseMap();
        CreateMap<ShopImage, DeleteShopImageCommand>().ReverseMap();
        CreateMap<ShopImage, DeletedShopImageResponse>().ReverseMap();
        CreateMap<ShopImage, GetByIdShopImageResponse>().ReverseMap();
        CreateMap<ShopImage, GetListShopImageListItemDto>().ReverseMap();
        CreateMap<IPaginate<ShopImage>, GetListResponse<GetListShopImageListItemDto>>().ReverseMap();
    }
}