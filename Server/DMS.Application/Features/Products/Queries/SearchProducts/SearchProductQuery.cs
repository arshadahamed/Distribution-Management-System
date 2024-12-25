using DMS.Application.Features.DTOs;
using MediatR;

namespace DMS.Application.Features.Products.Queries.SearchProducts;

public class SearchProductQuery : IRequest<IEnumerable<ProductDto>>
{
    public string? Keywords { get; set; }
   
}
