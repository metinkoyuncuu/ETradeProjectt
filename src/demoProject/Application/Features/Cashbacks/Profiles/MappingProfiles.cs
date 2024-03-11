using Application.Features.Cashbacks.Commands.Create;
using Application.Features.Cashbacks.Commands.Delete;
using Application.Features.Cashbacks.Commands.Update;
using Application.Features.Cashbacks.Queries.GetById;
using Application.Features.Cashbacks.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Cashbacks.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Cashback, CreateCashbackCommand>().ReverseMap();
        CreateMap<Cashback, CreatedCashbackResponse>().ReverseMap();
        CreateMap<Cashback, UpdateCashbackCommand>().ReverseMap();
        CreateMap<Cashback, UpdatedCashbackResponse>().ReverseMap();
        CreateMap<Cashback, DeleteCashbackCommand>().ReverseMap();
        CreateMap<Cashback, DeletedCashbackResponse>().ReverseMap();
        CreateMap<Cashback, GetByIdCashbackResponse>().ReverseMap();
        CreateMap<Cashback, GetListCashbackListItemDto>().ReverseMap();
        CreateMap<IPaginate<Cashback>, GetListResponse<GetListCashbackListItemDto>>().ReverseMap();
    }
}