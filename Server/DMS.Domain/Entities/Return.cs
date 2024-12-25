namespace DMS.Domain.Entities;

public class Return
{
    public int ReturnId { get; set; }
    public int InvoiceId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public string Reason { get; set; } // e.g., "Damaged", "Expired"
    public DateTime ReturnDate { get; set; }

    // Navigation
    public Invoice Invoice { get; set; }
    public Product Product { get; set; }
}
