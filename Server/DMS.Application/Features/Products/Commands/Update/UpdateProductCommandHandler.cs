using DMS.Application.Features.Interfaces;
using DMS.Domain.Entities;
using DMS.Domain.Exceptions;
using DMS.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DMS.Application.Features.Products.Commands.Update;

public class UpdateProductCommandHandler(ILogger<UpdateProductCommandHandler> logger,
    IProductRepository productRepository
    ) : IRequestHandler<UpdateProductCommand>
{
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling UpdateProductCommand for Product Id: {ProductId}", request.ProductId);

        var product = await productRepository.GetByIdAsync(request.ProductId);
        if (product == null)
        {
            logger.LogWarning("Product with Id {ProductId} not found.", request.ProductId);
            throw new NotFoundException(nameof(Product), request.ProductId.ToString());
        }

        if (request.ProductCode != null)
        {
            logger.LogInformation("Updating ProductCode for Product with Id {ProductId} to {ProductCode}", request.ProductId, request.ProductCode);
            product.ProductCode = request.ProductCode;
        }

        if (request.Name != null)
        {
            logger.LogInformation("Updating Name for Product with Id {ProductId} to {Name}", request.ProductId, request.Name);
            product.Name = request.Name;
        }

        if (request.Description != null)
        {
            logger.LogInformation("Updating Description for Product with Id {ProductId} to {Description}", request.ProductId, request.Description);
            product.Description = request.Description;
        }

        if (request.Cost != 0)
        {
            logger.LogInformation("Updating Cost for Product with Id {ProductId} to {Cost}", request.ProductId, request.Cost);
            product.Cost = request.Cost;
        }

        if (request.LabelPrice != 0)
        {
            logger.LogInformation("Updating LabelPrice for Product with Id {ProductId} to {LabelPrice}", request.ProductId, request.LabelPrice);
            product.LabelPrice = request.LabelPrice;
        }

        if (request.SellingPrice != 0)
        {
            logger.LogInformation("Updating SellingPrice for Product with Id {ProductId} to {SellingPrice}", request.ProductId, request.SellingPrice);
            product.SellingPrice = request.SellingPrice;
        }

        if (request.Supplier != null)
        {
            logger.LogInformation("Updating Supplier for Product with Id {ProductId} to {Supplier}", request.ProductId, request.Supplier);
            product.Supplier = request.Supplier;
        }

        if (request.Brand != null)
        {
            logger.LogInformation("Updating Brand for Product with Id {ProductId} to {Brand}", request.ProductId, request.Brand);
            product.Brand = request.Brand;
        }

        if (request.Category != null)
        {
            logger.LogInformation("Updating Category for Product with Id {ProductId} to {Category}", request.ProductId, request.Category);
            product.Category = request.Category;
        }

        if (request.Size != null)
        {
            logger.LogInformation("Updating Size for Product with Id {ProductId} to {Size}", request.ProductId, request.Size);
            product.Size = request.Size;
        }

        if (request.MeasuringUnit != null)
        {
            logger.LogInformation("Updating MeasuringUnit for Product with Id {ProductId} to {MeasuringUnit}", request.ProductId, request.MeasuringUnit);
            product.MeasuringUnit = request.MeasuringUnit;
        }

        await productRepository.Update(product);

        logger.LogInformation("Product with Id {ProductId} successfully updated.", request.ProductId);
    }
}
