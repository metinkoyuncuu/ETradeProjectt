using Application.Features.CustomerCompares.Commands.Create;
using Application.Features.CustomerCompares.Commands.Delete;
using Application.Features.CustomerCompares.Commands.Update;
using Application.Features.CustomerCompares.Queries.GetById;
using Application.Features.CustomerCompares.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CustomerCompares.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CustomerCompare, CreateCustomerCompareCommand>().ReverseMap();
        CreateMap<CustomerCompare, CreatedCustomerCompareResponse>().ReverseMap();
        CreateMap<CustomerCompare, UpdateCustomerCompareCommand>().ReverseMap();
        CreateMap<CustomerCompare, UpdatedCustomerCompareResponse>().ReverseMap();
        CreateMap<CustomerCompare, DeleteCustomerCompareCommand>().ReverseMap();
        CreateMap<CustomerCompare, DeletedCustomerCompareResponse>().ReverseMap();
        CreateMap<CustomerCompare, GetByIdCustomerCompareResponse>().ReverseMap();
        CreateMap<CustomerCompare, GetListCustomerCompareListItemDto>().ReverseMap();
        CreateMap<IPaginate<CustomerCompare>, GetListResponse<GetListCustomerCompareListItemDto>>().ReverseMap();
    }
}