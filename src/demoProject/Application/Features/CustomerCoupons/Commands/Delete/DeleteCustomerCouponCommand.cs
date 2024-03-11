using Application.Features.CustomerCoupons.Constants;
using Application.Features.CustomerCoupons.Constants;
using Application.Features.CustomerCoupons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomerCoupons.Constants.CustomerCouponsOperationClaims;

namespace Application.Features.CustomerCoupons.Commands.Delete;

public class DeleteCustomerCouponCommand : IRequest<DeletedCustomerCouponResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerCouponsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerCoupons";

    public class DeleteCustomerCouponCommandHandler : IRequestHandler<DeleteCustomerCouponCommand, DeletedCustomerCouponResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCouponRepository _customerCouponRepository;
        private readonly CustomerCouponBusinessRules _customerCouponBusinessRules;

        public DeleteCustomerCouponCommandHandler(IMapper mapper, ICustomerCouponRepository customerCouponRepository,
                                         CustomerCouponBusinessRules customerCouponBusinessRules)
        {
            _mapper = mapper;
            _customerCouponRepository = customerCouponRepository;
            _customerCouponBusinessRules = customerCouponBusinessRules;
        }

        public async Task<DeletedCustomerCouponResponse> Handle(DeleteCustomerCouponCommand request, CancellationToken cancellationToken)
        {
            CustomerCoupon? customerCoupon = await _customerCouponRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _customerCouponBusinessRules.CustomerCouponShouldExistWhenSelected(customerCoupon);

            await _customerCouponRepository.DeleteAsync(customerCoupon!);

            DeletedCustomerCouponResponse response = _mapper.Map<DeletedCustomerCouponResponse>(customerCoupon);
            return response;
        }
    }
}