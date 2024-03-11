using Application.Features.Coupons.Commands.Create;
using Application.Features.Coupons.Commands.Delete;
using Application.Features.Coupons.Commands.Update;
using Application.Features.Coupons.Queries.GetById;
using Application.Features.Coupons.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Coupons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Coupon, CreateCouponCommand>().ReverseMap();
        CreateMap<Coupon, CreatedCouponResponse>().ReverseMap();
        CreateMap<Coupon, UpdateCouponCommand>().ReverseMap();
        CreateMap<Coupon, UpdatedCouponResponse>().ReverseMap();
        CreateMap<Coupon, DeleteCouponCommand>().ReverseMap();
        CreateMap<Coupon, DeletedCouponResponse>().ReverseMap();
        CreateMap<Coupon, GetByIdCouponResponse>().ReverseMap();
        CreateMap<Coupon, GetListCouponListItemDto>().ReverseMap();
        CreateMap<IPaginate<Coupon>, GetListResponse<GetListCouponListItemDto>>().ReverseMap();
    }
}