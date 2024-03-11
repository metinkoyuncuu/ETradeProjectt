using Application.Features.Bills.Constants;
using Application.Features.Bills.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Bills.Constants.BillsOperationClaims;

namespace Application.Features.Bills.Commands.Create;

public class CreateBillCommand : IRequest<CreatedBillResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public int OrderId { get; set; }
    public string Header { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }

    public string[] Roles => new[] { Admin, Write, BillsOperationClaims.Create };

    public class CreateBillCommandHandler : IRequestHandler<CreateBillCommand, CreatedBillResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBillRepository _billRepository;
        private readonly BillBusinessRules _billBusinessRules;

        public CreateBillCommandHandler(IMapper mapper, IBillRepository billRepository,
                                         BillBusinessRules billBusinessRules)
        {
            _mapper = mapper;
            _billRepository = billRepository;
            _billBusinessRules = billBusinessRules;
        }

        public async Task<CreatedBillResponse> Handle(CreateBillCommand request, CancellationToken cancellationToken)
        {
            Bill bill = _mapper.Map<Bill>(request);

            await _billRepository.AddAsync(bill);

            CreatedBillResponse response = _mapper.Map<CreatedBillResponse>(bill);
            return response;
        }
    }
}