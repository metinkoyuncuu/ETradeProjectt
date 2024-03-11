using Application.Features.CustomerCoupons.Constants;
using Application.Features.CustomerCoupons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CustomerCoupons.Constants.CustomerCouponsOperationClaims;

namespace Application.Features.CustomerCoupons.Queries.GetById;

public class GetByIdCustomerCouponQuery : IRequest<GetByIdCustomerCouponResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCustomerCouponQueryHandler : IRequestHandler<GetByIdCustomerCouponQuery, GetByIdCustomerCouponResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCouponRepository _customerCouponRepository;
        private readonly CustomerCouponBusinessRules _customerCouponBusinessRules;

        public GetByIdCustomerCouponQueryHandler(IMapper mapper, ICustomerCouponRepository customerCouponRepository, CustomerCouponBusinessRules customerCouponBusinessRules)
        {
            _mapper = mapper;
            _customerCouponRepository = customerCouponRepository;
            _customerCouponBusinessRules = customerCouponBusinessRules;
        }

        public async Task<GetByIdCustomerCouponResponse> Handle(GetByIdCustomerCouponQuery request, CancellationToken cancellationToken)
        {
            CustomerCoupon? customerCoupon = await _customerCouponRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _customerCouponBusinessRules.CustomerCouponShouldExistWhenSelected(customerCoupon);

            GetByIdCustomerCouponResponse response = _mapper.Map<GetByIdCustomerCouponResponse>(customerCoupon);
            return response;
        }
    }
}