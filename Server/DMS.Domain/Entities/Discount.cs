namespace DMS.Domain.Entities;

public class Discount
{
    public int DiscountId { get; set; }
    public string DiscountType { get; set; } // e.g., "Percentage", "Fixed"
    public decimal Value { get; set; } // Discount value
    public int? ProductId { get; set; } // Optional product-specific discount
    public int? CustomerId { get; set; } // Optional customer-specific discount
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }

    // Navigation
    public Product Product { get; set; }
    public Customer Customer { get; set; }
}
