using Application.Features.ReviewFeedbacks.Commands.Create;
using Application.Features.ReviewFeedbacks.Commands.Delete;
using Application.Features.ReviewFeedbacks.Commands.Update;
using Application.Features.ReviewFeedbacks.Queries.GetById;
using Application.Features.ReviewFeedbacks.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ReviewFeedbacks.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ReviewFeedback, CreateReviewFeedbackCommand>().ReverseMap();
        CreateMap<ReviewFeedback, CreatedReviewFeedbackResponse>().ReverseMap();
        CreateMap<ReviewFeedback, UpdateReviewFeedbackCommand>().ReverseMap();
        CreateMap<ReviewFeedback, UpdatedReviewFeedbackResponse>().ReverseMap();
        CreateMap<ReviewFeedback, DeleteReviewFeedbackCommand>().ReverseMap();
        CreateMap<ReviewFeedback, DeletedReviewFeedbackResponse>().ReverseMap();
        CreateMap<ReviewFeedback, GetByIdReviewFeedbackResponse>().ReverseMap();
        CreateMap<ReviewFeedback, GetListReviewFeedbackListItemDto>().ReverseMap();
        CreateMap<IPaginate<ReviewFeedback>, GetListResponse<GetListReviewFeedbackListItemDto>>().ReverseMap();
    }
}