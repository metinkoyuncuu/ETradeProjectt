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

namespace Application.Features.Cashbacks.Commands.Create;

public class CreateCashbackCommand : IRequest<CreatedCashbackResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public float CashbackRatio { get; set; }

    public string[] Roles => new[] { Admin, Write, CashbacksOperationClaims.Create };

    public class CreateCashbackCommandHandler : IRequestHandler<CreateCashbackCommand, CreatedCashbackResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICashbackRepository _cashbackRepository;
        private readonly CashbackBusinessRules _cashbackBusinessRules;

        public CreateCashbackCommandHandler(IMapper mapper, ICashbackRepository cashbackRepository,
                                         CashbackBusinessRules cashbackBusinessRules)
        {
            _mapper = mapper;
            _cashbackRepository = cashbackRepository;
            _cashbackBusinessRules = cashbackBusinessRules;
        }

        public async Task<CreatedCashbackResponse> Handle(CreateCashbackCommand request, CancellationToken cancellationToken)
        {
            Cashback cashback = _mapper.Map<Cashback>(request);

            await _cashbackRepository.AddAsync(cashback);

            CreatedCashbackResponse response = _mapper.Map<CreatedCashbackResponse>(cashback);
            return response;
        }
    }
}