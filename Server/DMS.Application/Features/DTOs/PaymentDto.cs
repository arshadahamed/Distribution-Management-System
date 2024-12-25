namespace DMS.Application.Features.DTOs;

public class PaymentDto
{
    public int PaymentId { get; set; }
    public int InvoiceId { get; set; }
    public string PaymentMethod { get; set; }
    public string ChequeDetails { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
}
