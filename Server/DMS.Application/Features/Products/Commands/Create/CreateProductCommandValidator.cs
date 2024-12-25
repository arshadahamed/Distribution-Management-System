using FluentValidation;

namespace DMS.Application.Features.Products.Commands.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.ProductCode).NotEmpty().WithMessage("Product code is required.");
        RuleFor(p => p.Name).NotEmpty().WithMessage("Product name is required.");
        RuleFor(p => p.SellingPrice).GreaterThan(0).WithMessage("Selling price must be greater than 0.");
        RuleFor(p => p.Cost).GreaterThan(0).WithMessage("Cost must be greater than 0.");
    }
}
