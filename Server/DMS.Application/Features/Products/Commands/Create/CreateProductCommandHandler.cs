using AutoMapper;
using DMS.Application.Features.Interfaces;
using DMS.Domain.Entities;
using DMS.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DMS.Application.Features.Products.Commands.Create;

public class CreateProductCommandHandler(ILogger<CreateProductCommandHandler> logger, IMapper mapper, IProductRepository productRepository) : IRequestHandler<CreateProductCommand, int>
{
    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling CreateProductCommand for ProductCode: {ProductCode}", request.ProductCode);

        try
        {
            var product = mapper.Map<Product>(request);
            logger.LogInformation("Mapped Product entity: {@Product}", product);
            int id = await productRepository.Create(product);

            logger.LogInformation("Product created successfully with Id: {ProductId}", id);

            return id;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while creating the product with ProductCode: {ProductCode}", request.ProductCode);
            throw;
        }
    }
}
