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

namespace Application.Features.Bills.Commands.Update;

public class UpdateBillCommand : IRequest<UpdatedBillResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string Header { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }

    public string[] Roles => new[] { Admin, Write, BillsOperationClaims.Update };

    public class UpdateBillCommandHandler : IRequestHandler<UpdateBillCommand, UpdatedBillResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBillRepository _billRepository;
        private readonly BillBusinessRules _billBusinessRules;

        public UpdateBillCommandHandler(IMapper mapper, IBillRepository billRepository,
                                         BillBusinessRules billBusinessRules)
        {
            _mapper = mapper;
            _billRepository = billRepository;
            _billBusinessRules = billBusinessRules;
        }

        public async Task<UpdatedBillResponse> Handle(UpdateBillCommand request, CancellationToken cancellationToken)
        {
            Bill? bill = await _billRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _billBusinessRules.BillShouldExistWhenSelected(bill);
            bill = _mapper.Map(request, bill);

            await _billRepository.UpdateAsync(bill!);

            UpdatedBillResponse response = _mapper.Map<UpdatedBillResponse>(bill);
            return response;
        }
    }
}