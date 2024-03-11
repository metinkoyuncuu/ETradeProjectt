using Application.Features.Shippings.Commands.Create;
using Application.Features.Shippings.Commands.Delete;
using Application.Features.Shippings.Commands.Update;
using Application.Features.Shippings.Queries.GetById;
using Application.Features.Shippings.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Shippings.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Shipping, CreateShippingCommand>().ReverseMap();
        CreateMap<Shipping, CreatedShippingResponse>().ReverseMap();
        CreateMap<Shipping, UpdateShippingCommand>().ReverseMap();
        CreateMap<Shipping, UpdatedShippingResponse>().ReverseMap();
        CreateMap<Shipping, DeleteShippingCommand>().ReverseMap();
        CreateMap<Shipping, DeletedShippingResponse>().ReverseMap();
        CreateMap<Shipping, GetByIdShippingResponse>().ReverseMap();
        CreateMap<Shipping, GetListShippingListItemDto>().ReverseMap();
        CreateMap<IPaginate<Shipping>, GetListResponse<GetListShippingListItemDto>>().ReverseMap();
    }
}