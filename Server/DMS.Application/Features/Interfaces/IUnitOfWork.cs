using DMS.Domain.Entities;

namespace DMS.Application.Features.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Product> ProductRepository { get; }
    IRepository<Customer> CustomerRepository { get; }
    IRepository<Truck> TruckRepository { get; }
    IRepository<LoadedProduct> LoadedProductRepository { get; }
    IRepository<Invoice> InvoiceRepository { get; }
    IRepository<InvoiceLineItem> InvoiceLineItemRepository { get; }
    IRepository<Discount> DiscountRepository { get; }
    IRepository<Inventory> InventoryRepository { get; }
    IRepository<Return> ReturnRepository { get; }
    IRepository<Payment> PaymentRepository { get; }
    Task<int> CompleteAsync();
}

