using Application.Features.CustomerCompares.Constants;
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

namespace Application.Features.CustomerCompares.Commands.Delete;

public class DeleteCustomerCompareCommand : IRequest<DeletedCustomerCompareResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerComparesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerCompares";

    public class DeleteCustomerCompareCommandHandler : IRequestHandler<DeleteCustomerCompareCommand, DeletedCustomerCompareResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCompareRepository _customerCompareRepository;
        private readonly CustomerCompareBusinessRules _customerCompareBusinessRules;

        public DeleteCustomerCompareCommandHandler(IMapper mapper, ICustomerCompareRepository customerCompareRepository,
                                         CustomerCompareBusinessRules customerCompareBusinessRules)
        {
            _mapper = mapper;
            _customerCompareRepository = customerCompareRepository;
            _customerCompareBusinessRules = customerCompareBusinessRules;
        }

        public async Task<DeletedCustomerCompareResponse> Handle(DeleteCustomerCompareCommand request, CancellationToken cancellationToken)
        {
            CustomerCompare? customerCompare = await _customerCompareRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _customerCompareBusinessRules.CustomerCompareShouldExistWhenSelected(customerCompare);

            await _customerCompareRepository.DeleteAsync(customerCompare!);

            DeletedCustomerCompareResponse response = _mapper.Map<DeletedCustomerCompareResponse>(customerCompare);
            return response;
        }
    }
}