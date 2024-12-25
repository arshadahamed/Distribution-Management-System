namespace DMS.Application.Features.DTOs;

public class InvoiceDto
{
    public int InvoiceId { get; set; }
    public int CustomerId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal InvoiceDiscount { get; set; }
    public string PaymentMethod { get; set; }
    public decimal PaidAmount { get; set; }
}
