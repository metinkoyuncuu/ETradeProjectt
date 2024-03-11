using Application.Features.Bills.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Bills.Constants.BillsOperationClaims;

namespace Application.Features.Bills.Queries.GetList;

public class GetListBillQuery : IRequest<GetListResponse<GetListBillListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListBillQueryHandler : IRequestHandler<GetListBillQuery, GetListResponse<GetListBillListItemDto>>
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;

        public GetListBillQueryHandler(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBillListItemDto>> Handle(GetListBillQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Bill> bills = await _billRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBillListItemDto> response = _mapper.Map<GetListResponse<GetListBillListItemDto>>(bills);
            return response;
        }
    }
}