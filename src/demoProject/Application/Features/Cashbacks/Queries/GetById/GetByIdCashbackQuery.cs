using Application.Features.Cashbacks.Constants;
using Application.Features.Cashbacks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Cashbacks.Constants.CashbacksOperationClaims;

namespace Application.Features.Cashbacks.Queries.GetById;

public class GetByIdCashbackQuery : IRequest<GetByIdCashbackResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCashbackQueryHandler : IRequestHandler<GetByIdCashbackQuery, GetByIdCashbackResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICashbackRepository _cashbackRepository;
        private readonly CashbackBusinessRules _cashbackBusinessRules;

        public GetByIdCashbackQueryHandler(IMapper mapper, ICashbackRepository cashbackRepository, CashbackBusinessRules cashbackBusinessRules)
        {
            _mapper = mapper;
            _cashbackRepository = cashbackRepository;
            _cashbackBusinessRules = cashbackBusinessRules;
        }

        public async Task<GetByIdCashbackResponse> Handle(GetByIdCashbackQuery request, CancellationToken cancellationToken)
        {
            Cashback? cashback = await _cashbackRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _cashbackBusinessRules.CashbackShouldExistWhenSelected(cashback);

            GetByIdCashbackResponse response = _mapper.Map<GetByIdCashbackResponse>(cashback);
            return response;
        }
    }
}