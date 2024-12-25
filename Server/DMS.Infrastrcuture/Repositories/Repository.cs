using DMS.Application.Features.Interfaces;
using DMS.Infrastrcuture.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DMS.Infrastrcuture.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DMSDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(DMSDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }
}
