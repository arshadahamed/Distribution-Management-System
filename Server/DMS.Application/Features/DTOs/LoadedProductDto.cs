namespace DMS.Application.Features.DTOs;

public class LoadedProductDto
{
    public int LoadedProductId { get; set; }
    public int TruckId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal PricePerUnit { get; set; }
    public DateTime LoadingDate { get; set; }
}
