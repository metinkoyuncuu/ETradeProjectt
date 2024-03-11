using Application.Features.ProductCategories.Commands.Create;
using Application.Features.ProductCategories.Commands.Delete;
using Application.Features.ProductCategories.Commands.Update;
using Application.Features.ProductCategories.Queries.GetById;
using Application.Features.ProductCategories.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProductCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductCategory, CreateProductCategoryCommand>().ReverseMap();
        CreateMap<ProductCategory, CreatedProductCategoryResponse>().ReverseMap();
        CreateMap<ProductCategory, UpdateProductCategoryCommand>().ReverseMap();
        CreateMap<ProductCategory, UpdatedProductCategoryResponse>().ReverseMap();
        CreateMap<ProductCategory, DeleteProductCategoryCommand>().ReverseMap();
        CreateMap<ProductCategory, DeletedProductCategoryResponse>().ReverseMap();
        CreateMap<ProductCategory, GetByIdProductCategoryResponse>().ReverseMap();
        CreateMap<ProductCategory, GetListProductCategoryListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProductCategory>, GetListResponse<GetListProductCategoryListItemDto>>().ReverseMap();
    }
}