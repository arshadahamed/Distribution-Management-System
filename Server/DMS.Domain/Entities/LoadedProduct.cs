namespace DMS.Domain.Entities;

public class LoadedProduct
{
    public int LoadedProductId { get; set; }
    public int TruckId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal PricePerUnit { get; set; } // Assigned price at loading time
    public DateTime LoadingDate { get; set; }

    // Navigation
    public Truck Truck { get; set; }
    public Product Product { get; set; }
}
