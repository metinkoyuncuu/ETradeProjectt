using Application.Features.Bills.Constants;
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

namespace Application.Features.Bills.Commands.Delete;

public class DeleteBillCommand : IRequest<DeletedBillResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, BillsOperationClaims.Delete };

    public class DeleteBillCommandHandler : IRequestHandler<DeleteBillCommand, DeletedBillResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBillRepository _billRepository;
        private readonly BillBusinessRules _billBusinessRules;

        public DeleteBillCommandHandler(IMapper mapper, IBillRepository billRepository,
                                         BillBusinessRules billBusinessRules)
        {
            _mapper = mapper;
            _billRepository = billRepository;
            _billBusinessRules = billBusinessRules;
        }

        public async Task<DeletedBillResponse> Handle(DeleteBillCommand request, CancellationToken cancellationToken)
        {
            Bill? bill = await _billRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _billBusinessRules.BillShouldExistWhenSelected(bill);

            await _billRepository.DeleteAsync(bill!);

            DeletedBillResponse response = _mapper.Map<DeletedBillResponse>(bill);
            return response;
        }
    }
}