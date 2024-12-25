using AutoMapper;
using DMS.Application.Features.DTOs;
using DMS.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DMS.Application.Features.Products.Queries.SearchProducts
{
    public class SearchProductQueryHandler : IRequestHandler<SearchProductQuery, IEnumerable<ProductDto>>
    {
        private readonly ILogger<SearchProductQueryHandler> logger;
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public SearchProductQueryHandler(ILogger<SearchProductQueryHandler> logger, IMapper mapper, IProductRepository productRepository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> Handle(SearchProductQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handling SearchProductQuery with Keywords: {Keywords}", request.Keywords);

            var products = await productRepository.SearchBooksAsync(request.Keywords);

            if (products == null || !products.Any())
            {
                logger.LogInformation("No products found matching the search criteria.");
                return Enumerable.Empty<ProductDto>();
            }

            logger.LogInformation("{ProductCount} products found matching the search criteria.", products.Count());

            var productDtos = mapper.Map<IEnumerable<ProductDto>>(products);

            return productDtos;
        }
    }
}
