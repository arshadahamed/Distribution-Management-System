using DMS.Domain.Entities;
using DMS.Domain.Respositories;
using DMS.Infrastrcuture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DMS.Infrastrcuture.Repositories;

internal class ProductRepository(DMSDbContext dbContext) : IProductRepository
{
    public async Task<int> Create(Product product)
    {
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();
        return product.ProductId;
    }

    public async Task Delete(Product product)
    {
        dbContext.Remove(product);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = await dbContext.Products.ToListAsync();
        return products;
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        var product = await dbContext.Products
                 .FirstOrDefaultAsync(x => x.ProductId == id);
        return product;
    }

    public async Task<IEnumerable<Product>> SearchBooksAsync(string? keywords)
    {
        var query = dbContext.Products.AsQueryable();

        if (!string.IsNullOrEmpty(keywords))
        {
            var keywordsPattern = $"%{keywords}%";
            query = query.Where(b =>
                EF.Functions.Like(b.Brand, keywordsPattern) ||
                EF.Functions.Like(b.Category, keywordsPattern) ||
                EF.Functions.Like(b.Description, keywordsPattern) ||
                EF.Functions.Like(b.Name, keywordsPattern));
        }

        return await query.ToListAsync();
    }

    public async Task Update(Product product)
    {
        dbContext.Products.Update(product);
        await dbContext.SaveChangesAsync();
    }
}
