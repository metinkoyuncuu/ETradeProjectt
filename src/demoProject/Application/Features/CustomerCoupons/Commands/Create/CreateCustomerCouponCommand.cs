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

namespace Application.Features.CustomerCoupons.Commands.Create;

public class CreateCustomerCouponCommand : IRequest<CreatedCustomerCouponResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int CustomerId { get; set; }
    public int CouponId { get; set; }

    public string[] Roles => new[] { Admin, Write, CustomerCouponsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCustomerCoupons";

    public class CreateCustomerCouponCommandHandler : IRequestHandler<CreateCustomerCouponCommand, CreatedCustomerCouponResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCouponRepository _customerCouponRepository;
        private readonly CustomerCouponBusinessRules _customerCouponBusinessRules;

        public CreateCustomerCouponCommandHandler(IMapper mapper, ICustomerCouponRepository customerCouponRepository,
                                         CustomerCouponBusinessRules customerCouponBusinessRules)
        {
            _mapper = mapper;
            _customerCouponRepository = customerCouponRepository;
            _customerCouponBusinessRules = customerCouponBusinessRules;
        }

        public async Task<CreatedCustomerCouponResponse> Handle(CreateCustomerCouponCommand request, CancellationToken cancellationToken)
        {
            CustomerCoupon customerCoupon = _mapper.Map<CustomerCoupon>(request);

            await _customerCouponRepository.AddAsync(customerCoupon);

            CreatedCustomerCouponResponse response = _mapper.Map<CreatedCustomerCouponResponse>(customerCoupon);
            return response;
        }
    }
}