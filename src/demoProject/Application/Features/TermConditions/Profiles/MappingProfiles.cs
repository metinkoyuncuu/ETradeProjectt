using Application.Features.TermConditions.Commands.Create;
using Application.Features.TermConditions.Commands.Delete;
using Application.Features.TermConditions.Commands.Update;
using Application.Features.TermConditions.Queries.GetById;
using Application.Features.TermConditions.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.TermConditions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<TermCondition, CreateTermConditionCommand>().ReverseMap();
        CreateMap<TermCondition, CreatedTermConditionResponse>().ReverseMap();
        CreateMap<TermCondition, UpdateTermConditionCommand>().ReverseMap();
        CreateMap<TermCondition, UpdatedTermConditionResponse>().ReverseMap();
        CreateMap<TermCondition, DeleteTermConditionCommand>().ReverseMap();
        CreateMap<TermCondition, DeletedTermConditionResponse>().ReverseMap();
        CreateMap<TermCondition, GetByIdTermConditionResponse>().ReverseMap();
        CreateMap<TermCondition, GetListTermConditionListItemDto>().ReverseMap();
        CreateMap<IPaginate<TermCondition>, GetListResponse<GetListTermConditionListItemDto>>().ReverseMap();
    }
}