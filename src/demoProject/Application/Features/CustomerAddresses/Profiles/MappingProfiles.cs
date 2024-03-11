using Application.Features.CustomerAddresses.Commands.Create;
using Application.Features.CustomerAddresses.Commands.Delete;
using Application.Features.CustomerAddresses.Commands.Update;
using Application.Features.CustomerAddresses.Queries.GetById;
using Application.Features.CustomerAddresses.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CustomerAddresses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CustomerAddress, CreateCustomerAddressCommand>().ReverseMap();
        CreateMap<CustomerAddress, CreatedCustomerAddressResponse>().ReverseMap();
        CreateMap<CustomerAddress, UpdateCustomerAddressCommand>().ReverseMap();
        CreateMap<CustomerAddress, UpdatedCustomerAddressResponse>().ReverseMap();
        CreateMap<CustomerAddress, DeleteCustomerAddressCommand>().ReverseMap();
        CreateMap<CustomerAddress, DeletedCustomerAddressResponse>().ReverseMap();
        CreateMap<CustomerAddress, GetByIdCustomerAddressResponse>().ReverseMap();
        CreateMap<CustomerAddress, GetListCustomerAddressListItemDto>().ReverseMap();
        CreateMap<IPaginate<CustomerAddress>, GetListResponse<GetListCustomerAddressListItemDto>>().ReverseMap();
    }
}