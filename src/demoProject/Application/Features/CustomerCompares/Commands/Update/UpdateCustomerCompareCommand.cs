using Application.Features.CustomerCompares.Constants;
using Application.Features.CustomerCompares.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerCompares.Constants.CustomerComparesOperationClaims;

namespace Application.Features.CustomerCompares.Commands.Update;

public class UpdateCustomerCompareCommand : IRequest<UpdatedCustomerCompareResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerComparesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerCompares";

    public class UpdateCustomerCompareCommandHandler : IRequestHandler<UpdateCustomerCompareCommand, UpdatedCustomerCompareResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCompareRepository _customerCompareRepository;
        private readonly CustomerCompareBusinessRules _customerCompareBusinessRules;

        public UpdateCustomerCompareCommandHandler(IMapper mapper, ICustomerCompareRepository customerCompareRepository,
                                         CustomerCompareBusinessRules customerCompareBusinessRules)
        {
            _mapper = mapper;
            _customerCompareRepository = customerCompareRepository;
            _customerCompareBusinessRules = customerCompareBusinessRules;
        }

        public async Task<UpdatedCustomerCompareResponse> Handle(UpdateCustomerCompareCommand request, CancellationToken cancellationToken)
        {
            CustomerCompare? customerCompare = await _customerCompareRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _customerCompareBusinessRules.CustomerCompareShouldExistWhenSelected(customerCompare);
            customerCompare = _mapper.Map(request, customerCompare);

            await _customerCompareRepository.UpdateAsync(customerCompare!);

            UpdatedCustomerCompareResponse response = _mapper.Map<UpdatedCustomerCompareResponse>(customerCompare);
            return response;
        }
    }
}