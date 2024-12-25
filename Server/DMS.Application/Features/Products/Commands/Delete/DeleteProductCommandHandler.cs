using DMS.Domain.Entities;
using DMS.Domain.Exceptions;
using DMS.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DMS.Application.Features.Products.Commands.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly ILogger<DeleteProductCommandHandler> _logger;
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(ILogger<DeleteProductCommandHandler> logger, IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        // Log that the request to delete a product has been received
        _logger.LogInformation("Handling DeleteProductCommand for Product Id: {ProductId}", request.ProductId);

        var product = await _productRepository.GetByIdAsync(request.ProductId);

        if (product == null)
        {
            _logger.LogWarning("Product with Id {ProductId} not found.", request.ProductId);
            throw new NotFoundException(nameof(Product), request.ProductId.ToString());
        }

        await _productRepository.Delete(product);

        _logger.LogInformation("Product with Id {ProductId} has been deleted.", request.ProductId);

        return Unit.Value;
    }
}

