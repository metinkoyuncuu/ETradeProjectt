using Application.Features.Cashbacks.Constants;
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

namespace Application.Features.Cashbacks.Commands.Delete;

public class DeleteCashbackCommand : IRequest<DeletedCashbackResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CashbacksOperationClaims.Delete };

    public class DeleteCashbackCommandHandler : IRequestHandler<DeleteCashbackCommand, DeletedCashbackResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICashbackRepository _cashbackRepository;
        private readonly CashbackBusinessRules _cashbackBusinessRules;

        public DeleteCashbackCommandHandler(IMapper mapper, ICashbackRepository cashbackRepository,
                                         CashbackBusinessRules cashbackBusinessRules)
        {
            _mapper = mapper;
            _cashbackRepository = cashbackRepository;
            _cashbackBusinessRules = cashbackBusinessRules;
        }

        public async Task<DeletedCashbackResponse> Handle(DeleteCashbackCommand request, CancellationToken cancellationToken)
        {
            Cashback? cashback = await _cashbackRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _cashbackBusinessRules.CashbackShouldExistWhenSelected(cashback);

            await _cashbackRepository.DeleteAsync(cashback!);

            DeletedCashbackResponse response = _mapper.Map<DeletedCashbackResponse>(cashback);
            return response;
        }
    }
}