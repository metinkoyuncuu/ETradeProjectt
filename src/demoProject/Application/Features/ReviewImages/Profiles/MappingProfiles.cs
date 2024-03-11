using Application.Features.ReviewImages.Commands.Create;
using Application.Features.ReviewImages.Commands.Delete;
using Application.Features.ReviewImages.Commands.Update;
using Application.Features.ReviewImages.Queries.GetById;
using Application.Features.ReviewImages.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ReviewImages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ReviewImage, CreateReviewImageCommand>().ReverseMap();
        CreateMap<ReviewImage, CreatedReviewImageResponse>().ReverseMap();
        CreateMap<ReviewImage, UpdateReviewImageCommand>().ReverseMap();
        CreateMap<ReviewImage, UpdatedReviewImageResponse>().ReverseMap();
        CreateMap<ReviewImage, DeleteReviewImageCommand>().ReverseMap();
        CreateMap<ReviewImage, DeletedReviewImageResponse>().ReverseMap();
        CreateMap<ReviewImage, GetByIdReviewImageResponse>().ReverseMap();
        CreateMap<ReviewImage, GetListReviewImageListItemDto>().ReverseMap();
        CreateMap<IPaginate<ReviewImage>, GetListResponse<GetListReviewImageListItemDto>>().ReverseMap();
    }
}