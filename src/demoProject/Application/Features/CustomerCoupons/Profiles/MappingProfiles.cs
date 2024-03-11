using Application.Features.CustomerCoupons.Commands.Create;
using Application.Features.CustomerCoupons.Commands.Delete;
using Application.Features.CustomerCoupons.Commands.Update;
using Application.Features.CustomerCoupons.Queries.GetById;
using Application.Features.CustomerCoupons.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CustomerCoupons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CustomerCoupon, CreateCustomerCouponCommand>().ReverseMap();
        CreateMap<CustomerCoupon, CreatedCustomerCouponResponse>().ReverseMap();
        CreateMap<CustomerCoupon, UpdateCustomerCouponCommand>().ReverseMap();
        CreateMap<CustomerCoupon, UpdatedCustomerCouponResponse>().ReverseMap();
        CreateMap<CustomerCoupon, DeleteCustomerCouponCommand>().ReverseMap();
        CreateMap<CustomerCoupon, DeletedCustomerCouponResponse>().ReverseMap();
        CreateMap<CustomerCoupon, GetByIdCustomerCouponResponse>().ReverseMap();
        CreateMap<CustomerCoupon, GetListCustomerCouponListItemDto>().ReverseMap();
        CreateMap<IPaginate<CustomerCoupon>, GetListResponse<GetListCustomerCouponListItemDto>>().ReverseMap();
    }
}