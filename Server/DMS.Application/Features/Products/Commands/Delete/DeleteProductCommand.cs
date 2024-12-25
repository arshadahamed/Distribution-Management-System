using MediatR;

namespace DMS.Application.Features.Products.Commands.Delete;

public class DeleteProductCommand(int id) : IRequest
{
    public int ProductId { get; } = id;
}

