using Application.Features.ProductFeatures.Commands.Create;
using Application.Features.ProductFeatures.Commands.Delete;
using Application.Features.ProductFeatures.Commands.Update;
using Application.Features.ProductFeatures.Queries.GetById;
using Application.Features.ProductFeatures.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProductFeatures.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductFeature, CreateProductFeatureCommand>().ReverseMap();
        CreateMap<ProductFeature, CreatedProductFeatureResponse>().ReverseMap();
        CreateMap<ProductFeature, UpdateProductFeatureCommand>().ReverseMap();
        CreateMap<ProductFeature, UpdatedProductFeatureResponse>().ReverseMap();
        CreateMap<ProductFeature, DeleteProductFeatureCommand>().ReverseMap();
        CreateMap<ProductFeature, DeletedProductFeatureResponse>().ReverseMap();
        CreateMap<ProductFeature, GetByIdProductFeatureResponse>().ReverseMap();
        CreateMap<ProductFeature, GetListProductFeatureListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProductFeature>, GetListResponse<GetListProductFeatureListItemDto>>().ReverseMap();
    }
}