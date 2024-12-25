namespace DMS.Domain.Entities;

public class Invoice
{
    public int InvoiceId { get; set; }
    public int CustomerId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public decimal TotalAmount { get; set; } // Sum of line items
    public decimal InvoiceDiscount { get; set; } // Invoice-level discount
    public string PaymentMethod { get; set; } // e.g., Cash, Cheque, Online Payment
    public decimal PaidAmount { get; set; }

    // Navigation
    public Customer Customer { get; set; }
    public ICollection<InvoiceLineItem> LineItems { get; set; }
}
