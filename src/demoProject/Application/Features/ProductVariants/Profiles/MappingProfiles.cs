using Application.Features.ProductVariants.Commands.Create;
using Application.Features.ProductVariants.Commands.Delete;
using Application.Features.ProductVariants.Commands.Update;
using Application.Features.ProductVariants.Queries.GetById;
using Application.Features.ProductVariants.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProductVariants.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductVariant, CreateProductVariantCommand>().ReverseMap();
        CreateMap<ProductVariant, CreatedProductVariantResponse>().ReverseMap();
        CreateMap<ProductVariant, UpdateProductVariantCommand>().ReverseMap();
        CreateMap<ProductVariant, UpdatedProductVariantResponse>().ReverseMap();
        CreateMap<ProductVariant, DeleteProductVariantCommand>().ReverseMap();
        CreateMap<ProductVariant, DeletedProductVariantResponse>().ReverseMap();
        CreateMap<ProductVariant, GetByIdProductVariantResponse>().ReverseMap();
        CreateMap<ProductVariant, GetListProductVariantListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProductVariant>, GetListResponse<GetListProductVariantListItemDto>>().ReverseMap();
    }
}