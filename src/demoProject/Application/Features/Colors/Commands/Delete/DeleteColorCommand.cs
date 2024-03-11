using Application.Features.Colors.Constants;
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

namespace Application.Features.Colors.Commands.Delete;

public class DeleteColorCommand : IRequest<DeletedColorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ColorsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetColors";

    public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, DeletedColorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IColorRepository _colorRepository;
        private readonly ColorBusinessRules _colorBusinessRules;

        public DeleteColorCommandHandler(IMapper mapper, IColorRepository colorRepository,
                                         ColorBusinessRules colorBusinessRules)
        {
            _mapper = mapper;
            _colorRepository = colorRepository;
            _colorBusinessRules = colorBusinessRules;
        }

        public async Task<DeletedColorResponse> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {
            Color? color = await _colorRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _colorBusinessRules.ColorShouldExistWhenSelected(color);

            await _colorRepository.DeleteAsync(color!);

            DeletedColorResponse response = _mapper.Map<DeletedColorResponse>(color);
            return response;
        }
    }
}