namespace DMS.Domain.Entities;

public class Truck
{
    public int TruckId { get; set; }
    public string VehicleType { get; set; } // e.g., "Van", "Truck", "Pickup"
    public string VehicleNumber { get; set; }
    public string Driver { get; set; }
    public string Assistant { get; set; }

    // Navigation
    public ICollection<LoadedProduct> LoadedProducts { get; set; }
}
