using Application.Features.ProductQuestions.Commands.Create;
using Application.Features.ProductQuestions.Commands.Delete;
using Application.Features.ProductQuestions.Commands.Update;
using Application.Features.ProductQuestions.Queries.GetById;
using Application.Features.ProductQuestions.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProductQuestions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductQuestion, CreateProductQuestionCommand>().ReverseMap();
        CreateMap<ProductQuestion, CreatedProductQuestionResponse>().ReverseMap();
        CreateMap<ProductQuestion, UpdateProductQuestionCommand>().ReverseMap();
        CreateMap<ProductQuestion, UpdatedProductQuestionResponse>().ReverseMap();
        CreateMap<ProductQuestion, DeleteProductQuestionCommand>().ReverseMap();
        CreateMap<ProductQuestion, DeletedProductQuestionResponse>().ReverseMap();
        CreateMap<ProductQuestion, GetByIdProductQuestionResponse>().ReverseMap();
        CreateMap<ProductQuestion, GetListProductQuestionListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProductQuestion>, GetListResponse<GetListProductQuestionListItemDto>>().ReverseMap();
    }
}