using Application.Features.ProductReviews.Commands.Create;
using Application.Features.ProductReviews.Commands.Delete;
using Application.Features.ProductReviews.Commands.Update;
using Application.Features.ProductReviews.Queries.GetById;
using Application.Features.ProductReviews.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProductReviews.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductReview, CreateProductReviewCommand>().ReverseMap();
        CreateMap<ProductReview, CreatedProductReviewResponse>().ReverseMap();
        CreateMap<ProductReview, UpdateProductReviewCommand>().ReverseMap();
        CreateMap<ProductReview, UpdatedProductReviewResponse>().ReverseMap();
        CreateMap<ProductReview, DeleteProductReviewCommand>().ReverseMap();
        CreateMap<ProductReview, DeletedProductReviewResponse>().ReverseMap();
        CreateMap<ProductReview, GetByIdProductReviewResponse>().ReverseMap();
        CreateMap<ProductReview, GetListProductReviewListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProductReview>, GetListResponse<GetListProductReviewListItemDto>>().ReverseMap();
    }
}