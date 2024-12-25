namespace DMS.Domain.Entities;

public class InvoiceLineItem
{
    public int LineItemId { get; set; }
    public int InvoiceId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; } // Price at the time of sale
    public decimal DiscountPercentage { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal LineTotal => (Price - DiscountAmount) * Quantity; // Calculated total

    // Navigation
    public Invoice Invoice { get; set; }
    public Product Product { get; set; }
}
