using AutoMapper;
using DMS.Application.Features.DTOs;
using DMS.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DMS.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly ILogger<GetAllProductsQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        // Constructor  
        public GetAllProductsQueryHandler(
            ILogger<GetAllProductsQueryHandler> logger,
            IMapper mapper,
            IProductRepository productRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            // Fetch all products  
            var products = await _productRepository.GetAllAsync();

            // Log if no products are found  
            if (products == null || !products.Any())
            {
                _logger.LogInformation("No products found.");
                return Enumerable.Empty<ProductDto>(); // Return an empty collection if no products found  
            }
            else
            {
                _logger.LogInformation("Retrieved {ProductCount} products.", products.Count());
            }

            // Map to DTO  
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            // Log mapping  
            _logger.LogInformation("Mapped {ProductCount} products to ProductDto objects.", productDtos.Count());

            return productDtos;
        }
    }
}
