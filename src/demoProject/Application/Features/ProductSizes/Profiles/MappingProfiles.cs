using Application.Features.ProductSizes.Commands.Create;
using Application.Features.ProductSizes.Commands.Delete;
using Application.Features.ProductSizes.Commands.Update;
using Application.Features.ProductSizes.Queries.GetById;
using Application.Features.ProductSizes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProductSizes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductSize, CreateProductSizeCommand>().ReverseMap();
        CreateMap<ProductSize, CreatedProductSizeResponse>().ReverseMap();
        CreateMap<ProductSize, UpdateProductSizeCommand>().ReverseMap();
        CreateMap<ProductSize, UpdatedProductSizeResponse>().ReverseMap();
        CreateMap<ProductSize, DeleteProductSizeCommand>().ReverseMap();
        CreateMap<ProductSize, DeletedProductSizeResponse>().ReverseMap();
        CreateMap<ProductSize, GetByIdProductSizeResponse>().ReverseMap();
        CreateMap<ProductSize, GetListProductSizeListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProductSize>, GetListResponse<GetListProductSizeListItemDto>>().ReverseMap();
    }
}