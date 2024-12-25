namespace DMS.Application.Features.DTOs;

public class InventoryDto
{
    public int InventoryId { get; set; }
    public int ProductId { get; set; }
    public int WarehouseId { get; set; }
    public int Quantity { get; set; }
    public DateTime LastUpdated { get; set; }
}
