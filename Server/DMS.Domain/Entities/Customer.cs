namespace DMS.Domain.Entities;

public class Customer
{
    public int CustomerId { get; set; }
    public string CustomerType { get; set; } // Wholesale or Retail
    public string Name { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
    public decimal AccountBalance { get; set; } // Outstanding balance or credit

    // Navigation
    public ICollection<Invoice> Invoices { get; set; }
    public ICollection<Discount> Discounts { get; set; }
}
