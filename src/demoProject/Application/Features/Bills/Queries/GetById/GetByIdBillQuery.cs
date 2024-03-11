using Application.Features.Bills.Constants;
using Application.Features.Bills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Bills.Constants.BillsOperationClaims;

namespace Application.Features.Bills.Queries.GetById;

public class GetByIdBillQuery : IRequest<GetByIdBillResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdBillQueryHandler : IRequestHandler<GetByIdBillQuery, GetByIdBillResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBillRepository _billRepository;
        private readonly BillBusinessRules _billBusinessRules;

        public GetByIdBillQueryHandler(IMapper mapper, IBillRepository billRepository, BillBusinessRules billBusinessRules)
        {
            _mapper = mapper;
            _billRepository = billRepository;
            _billBusinessRules = billBusinessRules;
        }

        public async Task<GetByIdBillResponse> Handle(GetByIdBillQuery request, CancellationToken cancellationToken)
        {
            Bill? bill = await _billRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _billBusinessRules.BillShouldExistWhenSelected(bill);

            GetByIdBillResponse response = _mapper.Map<GetByIdBillResponse>(bill);
            return response;
        }
    }
}