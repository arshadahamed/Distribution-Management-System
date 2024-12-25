namespace DMS.Domain.Entities;

public class Payment
{
    public int PaymentId { get; set; }
    public int InvoiceId { get; set; }
    public string PaymentMethod { get; set; } // e.g., Cash, Cheque, Online
    public string ChequeDetails { get; set; } // If cheque payment
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }

    // Navigation
    public Invoice Invoice { get; set; }
}
