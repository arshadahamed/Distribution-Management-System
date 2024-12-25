namespace DMS.Domain.Entities;

public class Product
{
    public int ProductId { get; set; }
    public string ProductCode { get; set; } // Unique identifier for products
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
    public decimal LabelPrice { get; set; } // Retail price
    public decimal SellingPrice { get; set; } // Actual selling price
    public string Supplier { get; set; }
    public string Brand { get; set; }
    public string Category { get; set; }
    public string Size { get; set; } // e.g., "1L", "500g"
    public string MeasuringUnit { get; set; } // e.g., "liters", "kg"

    // Navigation
    public ICollection<LoadedProduct> LoadedProducts { get; set; }
    public ICollection<InvoiceLineItem> InvoiceLineItems { get; set; }
}
