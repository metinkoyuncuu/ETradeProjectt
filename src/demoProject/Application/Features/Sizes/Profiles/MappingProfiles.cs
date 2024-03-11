using Application.Features.Sizes.Commands.Create;
using Application.Features.Sizes.Commands.Delete;
using Application.Features.Sizes.Commands.Update;
using Application.Features.Sizes.Queries.GetById;
using Application.Features.Sizes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Sizes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Size, CreateSizeCommand>().ReverseMap();
        CreateMap<Size, CreatedSizeResponse>().ReverseMap();
        CreateMap<Size, UpdateSizeCommand>().ReverseMap();
        CreateMap<Size, UpdatedSizeResponse>().ReverseMap();
        CreateMap<Size, DeleteSizeCommand>().ReverseMap();
        CreateMap<Size, DeletedSizeResponse>().ReverseMap();
        CreateMap<Size, GetByIdSizeResponse>().ReverseMap();
        CreateMap<Size, GetListSizeListItemDto>().ReverseMap();
        CreateMap<IPaginate<Size>, GetListResponse<GetListSizeListItemDto>>().ReverseMap();
    }
}