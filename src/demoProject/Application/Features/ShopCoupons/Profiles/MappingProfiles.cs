using Application.Features.ShopCoupons.Commands.Create;
using Application.Features.ShopCoupons.Commands.Delete;
using Application.Features.ShopCoupons.Commands.Update;
using Application.Features.ShopCoupons.Queries.GetById;
using Application.Features.ShopCoupons.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ShopCoupons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ShopCoupon, CreateShopCouponCommand>().ReverseMap();
        CreateMap<ShopCoupon, CreatedShopCouponResponse>().ReverseMap();
        CreateMap<ShopCoupon, UpdateShopCouponCommand>().ReverseMap();
        CreateMap<ShopCoupon, UpdatedShopCouponResponse>().ReverseMap();
        CreateMap<ShopCoupon, DeleteShopCouponCommand>().ReverseMap();
        CreateMap<ShopCoupon, DeletedShopCouponResponse>().ReverseMap();
        CreateMap<ShopCoupon, GetByIdShopCouponResponse>().ReverseMap();
        CreateMap<ShopCoupon, GetListShopCouponListItemDto>().ReverseMap();
        CreateMap<IPaginate<ShopCoupon>, GetListResponse<GetListShopCouponListItemDto>>().ReverseMap();
    }
}