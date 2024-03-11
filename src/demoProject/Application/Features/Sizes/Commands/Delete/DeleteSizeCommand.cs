using Application.Features.Sizes.Constants;
using Application.Features.Sizes.Constants;
using Application.Features.Sizes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Sizes.Constants.SizesOperationClaims;

namespace Application.Features.Sizes.Commands.Delete;

public class DeleteSizeCommand : IRequest<DeletedSizeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, SizesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSizes";

    public class DeleteSizeCommandHandler : IRequestHandler<DeleteSizeCommand, DeletedSizeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISizeRepository _sizeRepository;
        private readonly SizeBusinessRules _sizeBusinessRules;

        public DeleteSizeCommandHandler(IMapper mapper, ISizeRepository sizeRepository,
                                         SizeBusinessRules sizeBusinessRules)
        {
            _mapper = mapper;
            _sizeRepository = sizeRepository;
            _sizeBusinessRules = sizeBusinessRules;
        }

        public async Task<DeletedSizeResponse> Handle(DeleteSizeCommand request, CancellationToken cancellationToken)
        {
            Size? size = await _sizeRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sizeBusinessRules.SizeShouldExistWhenSelected(size);

            await _sizeRepository.DeleteAsync(size!);

            DeletedSizeResponse response = _mapper.Map<DeletedSizeResponse>(size);
            return response;
        }
    }
}