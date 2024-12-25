using DMS.Domain.Entities;

namespace DMS.Domain.Respositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<IEnumerable<Product>> SearchBooksAsync(string? keywords);
    Task<Product?> GetByIdAsync(int id);
    Task<int> Create(Product product);
    Task Delete(Product product);
    Task Update(Product product);
}
