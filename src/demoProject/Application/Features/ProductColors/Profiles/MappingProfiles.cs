using Application.Features.ProductColors.Commands.Create;
using Application.Features.ProductColors.Commands.Delete;
using Application.Features.ProductColors.Commands.Update;
using Application.Features.ProductColors.Queries.GetById;
using Application.Features.ProductColors.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProductColors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductColor, CreateProductColorCommand>().ReverseMap();
        CreateMap<ProductColor, CreatedProductColorResponse>().ReverseMap();
        CreateMap<ProductColor, UpdateProductColorCommand>().ReverseMap();
        CreateMap<ProductColor, UpdatedProductColorResponse>().ReverseMap();
        CreateMap<ProductColor, DeleteProductColorCommand>().ReverseMap();
        CreateMap<ProductColor, DeletedProductColorResponse>().ReverseMap();
        CreateMap<ProductColor, GetByIdProductColorResponse>().ReverseMap();
        CreateMap<ProductColor, GetListProductColorListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProductColor>, GetListResponse<GetListProductColorListItemDto>>().ReverseMap();
    }
}