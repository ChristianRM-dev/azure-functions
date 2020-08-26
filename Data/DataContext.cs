using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // OrderDish Relations
            modelBuilder.Entity<OrderDish>()
                .HasKey(od => new { od.OrderId, od.ProductId });
            modelBuilder.Entity<OrderDish>()
                 .HasOne(o => o.Order)
                 .WithMany(op => op.OrderProducts)
                 .HasForeignKey(o => o.OrderId);
            modelBuilder.Entity<OrderDish>()
                .HasOne(p => p.Product)
                .WithMany(op => op.OrderProducts)
                .HasForeignKey(p => p.ProductId);

            //PackageProduct Relations
            modelBuilder.Entity<PackageProduct>()
                .HasKey(pp => new { pp.PackageId, pp.ProductId });
            modelBuilder.Entity<PackageProduct>()
                .HasOne(p => p.Package)
                .WithMany(pp => pp.PackageProducts)
                .HasForeignKey(p => p.PackageId);
            modelBuilder.Entity<PackageProduct>()
                .HasOne(p => p.Product)
                .WithMany(pp => pp.PackageProducts)
                .HasForeignKey(d => d.ProductId);

            //OrderPackage Relations
            modelBuilder.Entity<OrderPackage>()
                .HasKey(op => new { op.OrderId, op.PackageId });
            modelBuilder.Entity<OrderPackage>()
                .HasOne(o => o.Order)
                .WithMany(op => op.OrderPackages)
                .HasForeignKey(o => o.OrderId);
            modelBuilder.Entity<OrderPackage>()
                .HasOne(p => p.Package)
                .WithMany(op => op.OrderPackages)
                .HasForeignKey(p => p.PackageId);

            //Seedeing
            modelBuilder.Entity<Product>().HasData(
                new { ProductId = 1 , Name ="Envase Chico",Price = 35.00M},
                new { ProductId = 2, Name = "Envase Grande", Price = 85.00M },
                new { ProductId = 3, Name = "Envase Mediado", Price = 50.00M },
                new { ProductId = 4, Name = "Kilo", Price = 190.00M }
                );
            modelBuilder.Entity<Package>().HasData(
                new { PackageId = 1, Name="Paquete 1",Price = 190.00M, Available = false}
                );
            modelBuilder.Entity<PackageProduct>().HasData(
                new { PackageId = 1,ProductId = 4},
                new { PackageId = 1, ProductId = 2 }
                );
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Package> Packages { get; set; }
    }
}
