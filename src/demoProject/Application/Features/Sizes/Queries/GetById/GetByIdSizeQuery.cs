using Application.Features.Sizes.Constants;
using Application.Features.Sizes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Sizes.Constants.SizesOperationClaims;

namespace Application.Features.Sizes.Queries.GetById;

public class GetByIdSizeQuery : IRequest<GetByIdSizeResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdSizeQueryHandler : IRequestHandler<GetByIdSizeQuery, GetByIdSizeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISizeRepository _sizeRepository;
        private readonly SizeBusinessRules _sizeBusinessRules;

        public GetByIdSizeQueryHandler(IMapper mapper, ISizeRepository sizeRepository, SizeBusinessRules sizeBusinessRules)
        {
            _mapper = mapper;
            _sizeRepository = sizeRepository;
            _sizeBusinessRules = sizeBusinessRules;
        }

        public async Task<GetByIdSizeResponse> Handle(GetByIdSizeQuery request, CancellationToken cancellationToken)
        {
            Size? size = await _sizeRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sizeBusinessRules.SizeShouldExistWhenSelected(size);

            GetByIdSizeResponse response = _mapper.Map<GetByIdSizeResponse>(size);
            return response;
        }
    }
}