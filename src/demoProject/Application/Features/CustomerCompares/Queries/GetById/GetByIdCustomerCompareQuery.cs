using Application.Features.CustomerCompares.Constants;
using Application.Features.CustomerCompares.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerCompares.Constants.CustomerComparesOperationClaims;

namespace Application.Features.CustomerCompares.Queries.GetById;

public class GetByIdCustomerCompareQuery : IRequest<GetByIdCustomerCompareResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCustomerCompareQueryHandler : IRequestHandler<GetByIdCustomerCompareQuery, GetByIdCustomerCompareResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCompareRepository _customerCompareRepository;
        private readonly CustomerCompareBusinessRules _customerCompareBusinessRules;

        public GetByIdCustomerCompareQueryHandler(IMapper mapper, ICustomerCompareRepository customerCompareRepository, CustomerCompareBusinessRules customerCompareBusinessRules)
        {
            _mapper = mapper;
            _customerCompareRepository = customerCompareRepository;
            _customerCompareBusinessRules = customerCompareBusinessRules;
        }

        public async Task<GetByIdCustomerCompareResponse> Handle(GetByIdCustomerCompareQuery request, CancellationToken cancellationToken)
        {
            CustomerCompare? customerCompare = await _customerCompareRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _customerCompareBusinessRules.CustomerCompareShouldExistWhenSelected(customerCompare);

            GetByIdCustomerCompareResponse response = _mapper.Map<GetByIdCustomerCompareResponse>(customerCompare);
            return response;
        }
    }
}