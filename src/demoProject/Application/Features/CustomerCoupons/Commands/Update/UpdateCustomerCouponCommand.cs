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

namespace Application.Features.CustomerCoupons.Commands.Update;

public class UpdateCustomerCouponCommand : IRequest<UpdatedCustomerCouponResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int CouponId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerCouponsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerCoupons";

    public class UpdateCustomerCouponCommandHandler : IRequestHandler<UpdateCustomerCouponCommand, UpdatedCustomerCouponResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCouponRepository _customerCouponRepository;
        private readonly CustomerCouponBusinessRules _customerCouponBusinessRules;

        public UpdateCustomerCouponCommandHandler(IMapper mapper, ICustomerCouponRepository customerCouponRepository,
                                         CustomerCouponBusinessRules customerCouponBusinessRules)
        {
            _mapper = mapper;
            _customerCouponRepository = customerCouponRepository;
            _customerCouponBusinessRules = customerCouponBusinessRules;
        }

        public async Task<UpdatedCustomerCouponResponse> Handle(UpdateCustomerCouponCommand request, CancellationToken cancellationToken)
        {
            CustomerCoupon? customerCoupon = await _customerCouponRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _customerCouponBusinessRules.CustomerCouponShouldExistWhenSelected(customerCoupon);
            customerCoupon = _mapper.Map(request, customerCoupon);

            await _customerCouponRepository.UpdateAsync(customerCoupon!);

            UpdatedCustomerCouponResponse response = _mapper.Map<UpdatedCustomerCouponResponse>(customerCoupon);
            return response;
        }
    }
}