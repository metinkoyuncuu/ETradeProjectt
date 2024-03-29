using Application.Features.Colors.Constants;
using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Colors.Constants.ColorsOperationClaims;

namespace Application.Features.Colors.Commands.Create;

public class CreateColorCommand : IRequest<CreatedColorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public bool IsVerified { get; set; }

    public string[] Roles => new[] { Admin, Write, ColorsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetColors";

    public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, CreatedColorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IColorRepository _colorRepository;
        private readonly ColorBusinessRules _colorBusinessRules;

        public CreateColorCommandHandler(IMapper mapper, IColorRepository colorRepository,
                                         ColorBusinessRules colorBusinessRules)
        {
            _mapper = mapper;
            _colorRepository = colorRepository;
            _colorBusinessRules = colorBusinessRules;
        }

        public async Task<CreatedColorResponse> Handle(CreateColorCommand request, CancellationToken cancellationToken)
        {
            Color color = _mapper.Map<Color>(request);

            await _colorRepository.AddAsync(color);

            CreatedColorResponse response = _mapper.Map<CreatedColorResponse>(color);
            return response;
        }
    }
}