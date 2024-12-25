namespace DMS.Application.Features.DTOs;

public class CustomerDto
{
    public int CustomerId { get; set; }
    public string CustomerType { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
    public decimal AccountBalance { get; set; }
}
