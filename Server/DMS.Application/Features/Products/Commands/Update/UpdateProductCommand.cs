using MediatR;

namespace DMS.Application.Features.Products.Commands.Update;

public class UpdateProductCommand : IRequest
{
    public int ProductId { get; set; }
    public string ProductCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
    public decimal LabelPrice { get; set; }
    public decimal SellingPrice { get; set; }
    public string Supplier { get; set; }
    public string Brand { get; set; }
    public string Category { get; set; }
    public string Size { get; set; }
    public string MeasuringUnit { get; set; }

}
