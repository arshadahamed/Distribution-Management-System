using DMS.Application.Features.DTOs;
using MediatR;

namespace DMS.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
{

}
