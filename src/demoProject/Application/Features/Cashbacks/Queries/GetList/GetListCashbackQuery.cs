using Application.Features.Cashbacks.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Cashbacks.Constants.CashbacksOperationClaims;

namespace Application.Features.Cashbacks.Queries.GetList;

public class GetListCashbackQuery : IRequest<GetListResponse<GetListCashbackListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListCashbackQueryHandler : IRequestHandler<GetListCashbackQuery, GetListResponse<GetListCashbackListItemDto>>
    {
        private readonly ICashbackRepository _cashbackRepository;
        private readonly IMapper _mapper;

        public GetListCashbackQueryHandler(ICashbackRepository cashbackRepository, IMapper mapper)
        {
            _cashbackRepository = cashbackRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCashbackListItemDto>> Handle(GetListCashbackQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Cashback> cashbacks = await _cashbackRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCashbackListItemDto> response = _mapper.Map<GetListResponse<GetListCashbackListItemDto>>(cashbacks);
            return response;
        }
    }
}