using Application.Features.ProductTags.Constants;
using Application.Features.ProductTags.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ProductTags.Constants.ProductTagsOperationClaims;

namespace Application.Features.ProductTags.Queries.GetById;

public class GetByIdProductTagQuery : IRequest<GetByIdProductTagResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdProductTagQueryHandler : IRequestHandler<GetByIdProductTagQuery, GetByIdProductTagResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductTagRepository _productTagRepository;
        private readonly ProductTagBusinessRules _productTagBusinessRules;

        public GetByIdProductTagQueryHandler(IMapper mapper, IProductTagRepository productTagRepository, ProductTagBusinessRules productTagBusinessRules)
        {
            _mapper = mapper;
            _productTagRepository = productTagRepository;
            _productTagBusinessRules = productTagBusinessRules;
        }

        public async Task<GetByIdProductTagResponse> Handle(GetByIdProductTagQuery request, CancellationToken cancellationToken)
        {
            ProductTag? productTag = await _productTagRepository.GetAsync(predicate: pt => pt.Id == request.Id, cancellationToken: cancellationToken);
            await _productTagBusinessRules.ProductTagShouldExistWhenSelected(productTag);

            GetByIdProductTagResponse response = _mapper.Map<GetByIdProductTagResponse>(productTag);
            return response;
        }
    }
}