using Application.Features.ProductTags.Commands.Create;
using Application.Features.ProductTags.Commands.Delete;
using Application.Features.ProductTags.Commands.Update;
using Application.Features.ProductTags.Queries.GetById;
using Application.Features.ProductTags.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProductTags.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductTag, CreateProductTagCommand>().ReverseMap();
        CreateMap<ProductTag, CreatedProductTagResponse>().ReverseMap();
        CreateMap<ProductTag, UpdateProductTagCommand>().ReverseMap();
        CreateMap<ProductTag, UpdatedProductTagResponse>().ReverseMap();
        CreateMap<ProductTag, DeleteProductTagCommand>().ReverseMap();
        CreateMap<ProductTag, DeletedProductTagResponse>().ReverseMap();
        CreateMap<ProductTag, GetByIdProductTagResponse>().ReverseMap();
        CreateMap<ProductTag, GetListProductTagListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProductTag>, GetListResponse<GetListProductTagListItemDto>>().ReverseMap();
    }
}