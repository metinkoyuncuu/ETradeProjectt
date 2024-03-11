using Application.Features.CustomerCreditCards.Commands.Create;
using Application.Features.CustomerCreditCards.Commands.Delete;
using Application.Features.CustomerCreditCards.Commands.Update;
using Application.Features.CustomerCreditCards.Queries.GetById;
using Application.Features.CustomerCreditCards.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CustomerCreditCards.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CustomerCreditCard, CreateCustomerCreditCardCommand>().ReverseMap();
        CreateMap<CustomerCreditCard, CreatedCustomerCreditCardResponse>().ReverseMap();
        CreateMap<CustomerCreditCard, UpdateCustomerCreditCardCommand>().ReverseMap();
        CreateMap<CustomerCreditCard, UpdatedCustomerCreditCardResponse>().ReverseMap();
        CreateMap<CustomerCreditCard, DeleteCustomerCreditCardCommand>().ReverseMap();
        CreateMap<CustomerCreditCard, DeletedCustomerCreditCardResponse>().ReverseMap();
        CreateMap<CustomerCreditCard, GetByIdCustomerCreditCardResponse>().ReverseMap();
        CreateMap<CustomerCreditCard, GetListCustomerCreditCardListItemDto>().ReverseMap();
        CreateMap<IPaginate<CustomerCreditCard>, GetListResponse<GetListCustomerCreditCardListItemDto>>().ReverseMap();
    }
}