namespace DMS.Application.Features.DTOs;

public class DiscountDto
{
    public int DiscountId { get; set; }
    public string DiscountType { get; set; }
    public decimal Value { get; set; }
    public int? ProductId { get; set; }
    public int? CustomerId { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
}
