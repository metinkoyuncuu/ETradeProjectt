using Application.Features.ProductFeatureTables.Commands.Create;
using Application.Features.ProductFeatureTables.Commands.Delete;
using Application.Features.ProductFeatureTables.Commands.Update;
using Application.Features.ProductFeatureTables.Queries.GetById;
using Application.Features.ProductFeatureTables.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProductFeatureTables.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductFeatureTable, CreateProductFeatureTableCommand>().ReverseMap();
        CreateMap<ProductFeatureTable, CreatedProductFeatureTableResponse>().ReverseMap();
        CreateMap<ProductFeatureTable, UpdateProductFeatureTableCommand>().ReverseMap();
        CreateMap<ProductFeatureTable, UpdatedProductFeatureTableResponse>().ReverseMap();
        CreateMap<ProductFeatureTable, DeleteProductFeatureTableCommand>().ReverseMap();
        CreateMap<ProductFeatureTable, DeletedProductFeatureTableResponse>().ReverseMap();
        CreateMap<ProductFeatureTable, GetByIdProductFeatureTableResponse>().ReverseMap();
        CreateMap<ProductFeatureTable, GetListProductFeatureTableListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProductFeatureTable>, GetListResponse<GetListProductFeatureTableListItemDto>>().ReverseMap();
    }
}