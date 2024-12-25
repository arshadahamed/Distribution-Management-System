using DMS.Application.Features.Interfaces;
using DMS.Domain.Entities;
using DMS.Infrastrcuture.Repositories;

namespace DMS.Infrastrcuture.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly DMSDbContext _context;

    public IRepository<Product> ProductRepository { get; private set; }
    public IRepository<Customer> CustomerRepository { get; private set; }
    public IRepository<Truck> TruckRepository { get; private set; }
    public IRepository<LoadedProduct> LoadedProductRepository { get; private set; }
    public IRepository<Invoice> InvoiceRepository { get; private set; }
    public IRepository<InvoiceLineItem> InvoiceLineItemRepository { get; private set; }
    public IRepository<Discount> DiscountRepository { get; private set; }
    public IRepository<Inventory> InventoryRepository { get; private set; }
    public IRepository<Return> ReturnRepository { get; private set; }
    public IRepository<Payment> PaymentRepository { get; private set; }

    public UnitOfWork(DMSDbContext context)
    {
        _context = context;
        ProductRepository = new Repository<Product>(_context);
        CustomerRepository = new Repository<Customer>(_context);
        TruckRepository = new Repository<Truck>(_context);
        LoadedProductRepository = new Repository<LoadedProduct>(_context);
        InvoiceRepository = new Repository<Invoice>(_context);
        InvoiceLineItemRepository = new Repository<InvoiceLineItem>(_context);
        DiscountRepository = new Repository<Discount>(_context);
        InventoryRepository = new Repository<Inventory>(_context);
        ReturnRepository = new Repository<Return>(_context);
        PaymentRepository = new Repository<Payment>(_context);
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}