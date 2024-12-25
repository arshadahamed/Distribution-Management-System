
using AutoMapper;
using DMS.Application.Features.DTOs;
using DMS.Domain.Entities;
using DMS.Domain.Exceptions;
using DMS.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DMS.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly ILogger<GetProductByIdQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(ILogger<GetProductByIdQueryHandler> logger, IMapper mapper, IProductRepository productRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling GetProductByIdQuery for ProductId: {ProductId}", request.ProductId);

        var product = await _productRepository.GetByIdAsync(request.ProductId);

        if (product == null)
        {
            _logger.LogWarning("Product with Id {ProductId} not found.", request.ProductId);
            throw new NotFoundException(nameof(Product), request.ProductId.ToString());
        }

        var productDto = _mapper.Map<ProductDto>(product);

        _logger.LogInformation("Successfully retrieved and mapped Product with Id {ProductId} to ProductDto.", request.ProductId);

        return productDto;
    }
}

