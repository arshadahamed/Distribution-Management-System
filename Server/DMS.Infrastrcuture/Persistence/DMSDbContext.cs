using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DMS.Domain.Entities;

namespace DMS.Infrastrcuture.Persistence;

public class DMSDbContext(DbContextOptions<DMSDbContext> options) : IdentityDbContext<IdentityUser>(options)
{
    // DbSets for all entities
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Truck> Trucks { get; set; }
    public DbSet<LoadedProduct> LoadedProducts { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Return> Returns { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Product Configuration
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.ProductId);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
            entity.Property(p => p.ProductCode).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Cost).HasColumnType("decimal(18,2)");
            entity.Property(p => p.LabelPrice).HasColumnType("decimal(18,2)");
            entity.Property(p => p.SellingPrice).HasColumnType("decimal(18,2)");
        });

        // Customer Configuration
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(c => c.CustomerId);
            entity.Property(c => c.Name).IsRequired().HasMaxLength(150);
            entity.Property(c => c.Contact).HasMaxLength(50);
            entity.Property(c => c.AccountBalance).HasColumnType("decimal(18,2)");
        });

        // Truck Configuration
        modelBuilder.Entity<Truck>(entity =>
        {
            entity.HasKey(t => t.TruckId);
            entity.Property(t => t.VehicleType).IsRequired().HasMaxLength(50);
            entity.Property(t => t.VehicleNumber).IsRequired().HasMaxLength(20);
            entity.Property(t => t.Driver).HasMaxLength(100);
            entity.Property(t => t.Assistant).HasMaxLength(100);
        });

        // LoadedProduct Configuration
        modelBuilder.Entity<LoadedProduct>(entity =>
        {
            entity.HasKey(lp => lp.LoadedProductId);
            entity.Property(lp => lp.PricePerUnit).HasColumnType("decimal(18,2)");
            entity.Property(lp => lp.Quantity).IsRequired();

            entity.HasOne(lp => lp.Truck)
                  .WithMany(t => t.LoadedProducts)
                  .HasForeignKey(lp => lp.TruckId);

            entity.HasOne(lp => lp.Product)
                  .WithMany(p => p.LoadedProducts)
                  .HasForeignKey(lp => lp.ProductId);
        });

        // Invoice Configuration
        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(i => i.InvoiceId);
            entity.Property(i => i.TotalAmount).HasColumnType("decimal(18,2)");
            entity.Property(i => i.InvoiceDiscount).HasColumnType("decimal(18,2)");
            entity.Property(i => i.PaidAmount).HasColumnType("decimal(18,2)");
            entity.Property(i => i.PaymentMethod).HasMaxLength(50);

            entity.HasOne(i => i.Customer)
                  .WithMany(c => c.Invoices)
                  .HasForeignKey(i => i.CustomerId);
        });

        // InvoiceLineItem Configuration
        modelBuilder.Entity<InvoiceLineItem>(entity =>
        {
            entity.HasKey(ili => ili.LineItemId);
            entity.Property(ili => ili.Price).HasColumnType("decimal(18,2)");
            entity.Property(ili => ili.DiscountAmount).HasColumnType("decimal(18,2)");
            entity.Property(ili => ili.DiscountPercentage).HasColumnType("decimal(5,2)");

            entity.HasOne(ili => ili.Invoice)
                  .WithMany(i => i.LineItems)
                  .HasForeignKey(ili => ili.InvoiceId);

            entity.HasOne(ili => ili.Product)
                  .WithMany(p => p.InvoiceLineItems)
                  .HasForeignKey(ili => ili.ProductId);
        });

        // Discount Configuration
        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(d => d.DiscountId);
            entity.Property(d => d.Value).HasColumnType("decimal(18,2)");
            entity.Property(d => d.DiscountType).HasMaxLength(20);

            entity.HasOne(d => d.Product)
                  .WithMany()
                  .HasForeignKey(d => d.ProductId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Customer)
                  .WithMany(c => c.Discounts)
                  .HasForeignKey(d => d.CustomerId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Inventory Configuration
        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(i => i.InventoryId);
            entity.Property(i => i.Quantity).IsRequired();

            entity.HasOne(i => i.Product)
                  .WithMany()
                  .HasForeignKey(i => i.ProductId);
        });

        // Return Configuration
        modelBuilder.Entity<Return>(entity =>
        {
            entity.HasKey(r => r.ReturnId);
            entity.Property(r => r.Price).HasColumnType("decimal(18,2)");
            entity.Property(r => r.Discount).HasColumnType("decimal(18,2)");
            entity.Property(r => r.Reason).HasMaxLength(250);

            entity.HasOne(r => r.Invoice)
                  .WithMany()
                  .HasForeignKey(r => r.InvoiceId);

            entity.HasOne(r => r.Product)
                  .WithMany()
                  .HasForeignKey(r => r.ProductId);
        });

        // Payment Configuration
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(p => p.PaymentId);
            entity.Property(p => p.Amount).HasColumnType("decimal(18,2)");
            entity.Property(p => p.PaymentMethod).HasMaxLength(50);
            entity.Property(p => p.ChequeDetails).HasMaxLength(250);

            entity.HasOne(p => p.Invoice)
                  .WithMany()
                  .HasForeignKey(p => p.InvoiceId);
        });
    }
}
