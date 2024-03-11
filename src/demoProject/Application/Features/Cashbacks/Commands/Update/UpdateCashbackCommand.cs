using Application.Features.Cashbacks.Constants;
using Application.Features.Cashbacks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Cashbacks.Constants.CashbacksOperationClaims;

namespace Application.Features.Cashbacks.Commands.Update;

public class UpdateCashbackCommand : IRequest<UpdatedCashbackResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public float CashbackRatio { get; set; }

    public string[] Roles => new[] { Admin, Write, CashbacksOperationClaims.Update };

    public class UpdateCashbackCommandHandler : IRequestHandler<UpdateCashbackCommand, UpdatedCashbackResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICashbackRepository _cashbackRepository;
        private readonly CashbackBusinessRules _cashbackBusinessRules;

        public UpdateCashbackCommandHandler(IMapper mapper, ICashbackRepository cashbackRepository,
                                         CashbackBusinessRules cashbackBusinessRules)
        {
            _mapper = mapper;
            _cashbackRepository = cashbackRepository;
            _cashbackBusinessRules = cashbackBusinessRules;
        }

        public async Task<UpdatedCashbackResponse> Handle(UpdateCashbackCommand request, CancellationToken cancellationToken)
        {
            Cashback? cashback = await _cashbackRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _cashbackBusinessRules.CashbackShouldExistWhenSelected(cashback);
            cashback = _mapper.Map(request, cashback);

            await _cashbackRepository.UpdateAsync(cashback!);

            UpdatedCashbackResponse response = _mapper.Map<UpdatedCashbackResponse>(cashback);
            return response;
        }
    }
}