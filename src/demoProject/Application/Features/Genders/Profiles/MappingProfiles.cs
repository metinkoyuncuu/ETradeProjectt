using Application.Features.Genders.Commands.Create;
using Application.Features.Genders.Commands.Delete;
using Application.Features.Genders.Commands.Update;
using Application.Features.Genders.Queries.GetById;
using Application.Features.Genders.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Genders.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Gender, CreateGenderCommand>().ReverseMap();
        CreateMap<Gender, CreatedGenderResponse>().ReverseMap();
        CreateMap<Gender, UpdateGenderCommand>().ReverseMap();
        CreateMap<Gender, UpdatedGenderResponse>().ReverseMap();
        CreateMap<Gender, DeleteGenderCommand>().ReverseMap();
        CreateMap<Gender, DeletedGenderResponse>().ReverseMap();
        CreateMap<Gender, GetByIdGenderResponse>().ReverseMap();
        CreateMap<Gender, GetListGenderListItemDto>().ReverseMap();
        CreateMap<IPaginate<Gender>, GetListResponse<GetListGenderListItemDto>>().ReverseMap();
    }
}