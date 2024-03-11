using Application.Features.Sellers.Commands.Create;
using Application.Features.Sellers.Commands.Delete;
using Application.Features.Sellers.Commands.Update;
using Application.Features.Sellers.Queries.GetById;
using Application.Features.Sellers.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Sellers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Seller, CreateSellerCommand>().ReverseMap();
        CreateMap<Seller, CreatedSellerResponse>().ReverseMap();
        CreateMap<Seller, UpdateSellerCommand>().ReverseMap();
        CreateMap<Seller, UpdatedSellerResponse>().ReverseMap();
        CreateMap<Seller, DeleteSellerCommand>().ReverseMap();
        CreateMap<Seller, DeletedSellerResponse>().ReverseMap();
        CreateMap<Seller, GetByIdSellerResponse>().ReverseMap();
        CreateMap<Seller, GetListSellerListItemDto>().ReverseMap();
        CreateMap<IPaginate<Seller>, GetListResponse<GetListSellerListItemDto>>().ReverseMap();
    }
}