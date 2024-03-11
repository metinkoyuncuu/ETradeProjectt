using Application.Features.ProductColors.Constants;
using Application.Features.ProductColors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ProductColors.Constants.ProductColorsOperationClaims;

namespace Application.Features.ProductColors.Queries.GetById;

public class GetByIdProductColorQuery : IRequest<GetByIdProductColorResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdProductColorQueryHandler : IRequestHandler<GetByIdProductColorQuery, GetByIdProductColorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductColorRepository _productColorRepository;
        private readonly ProductColorBusinessRules _productColorBusinessRules;

        public GetByIdProductColorQueryHandler(IMapper mapper, IProductColorRepository productColorRepository, ProductColorBusinessRules productColorBusinessRules)
        {
            _mapper = mapper;
            _productColorRepository = productColorRepository;
            _productColorBusinessRules = productColorBusinessRules;
        }

        public async Task<GetByIdProductColorResponse> Handle(GetByIdProductColorQuery request, CancellationToken cancellationToken)
        {
            ProductColor? productColor = await _productColorRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _productColorBusinessRules.ProductColorShouldExistWhenSelected(productColor);

            GetByIdProductColorResponse response = _mapper.Map<GetByIdProductColorResponse>(productColor);
            return response;
        }
    }
}