using Application.Features.Bills.Commands.Create;
using Application.Features.Bills.Commands.Delete;
using Application.Features.Bills.Commands.Update;
using Application.Features.Bills.Queries.GetById;
using Application.Features.Bills.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Bills.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Bill, CreateBillCommand>().ReverseMap();
        CreateMap<Bill, CreatedBillResponse>().ReverseMap();
        CreateMap<Bill, UpdateBillCommand>().ReverseMap();
        CreateMap<Bill, UpdatedBillResponse>().ReverseMap();
        CreateMap<Bill, DeleteBillCommand>().ReverseMap();
        CreateMap<Bill, DeletedBillResponse>().ReverseMap();
        CreateMap<Bill, GetByIdBillResponse>().ReverseMap();
        CreateMap<Bill, GetListBillListItemDto>().ReverseMap();
        CreateMap<IPaginate<Bill>, GetListResponse<GetListBillListItemDto>>().ReverseMap();
    }
}