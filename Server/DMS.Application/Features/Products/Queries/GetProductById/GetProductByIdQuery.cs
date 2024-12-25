using DMS.Application.Features.DTOs;
using MediatR;

namespace DMS.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQuery(int id) : IRequest<ProductDto>
{
    public int ProductId { get; set; } = id;

}
