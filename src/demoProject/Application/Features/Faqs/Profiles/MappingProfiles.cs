using Application.Features.Faqs.Commands.Create;
using Application.Features.Faqs.Commands.Delete;
using Application.Features.Faqs.Commands.Update;
using Application.Features.Faqs.Queries.GetById;
using Application.Features.Faqs.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Faqs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Faq, CreateFaqCommand>().ReverseMap();
        CreateMap<Faq, CreatedFaqResponse>().ReverseMap();
        CreateMap<Faq, UpdateFaqCommand>().ReverseMap();
        CreateMap<Faq, UpdatedFaqResponse>().ReverseMap();
        CreateMap<Faq, DeleteFaqCommand>().ReverseMap();
        CreateMap<Faq, DeletedFaqResponse>().ReverseMap();
        CreateMap<Faq, GetByIdFaqResponse>().ReverseMap();
        CreateMap<Faq, GetListFaqListItemDto>().ReverseMap();
        CreateMap<IPaginate<Faq>, GetListResponse<GetListFaqListItemDto>>().ReverseMap();
    }
}