using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Market.Domain.Entities.Catalog;
using Market.Domain.Entities.Sales;
using Market.Domain.Entities.Identity;

namespace Market.Infrastructure.Database.Seeders;

/// <summary>
/// Dynamic seeder koji se pokreće u runtime-u,
/// obično pri startu aplikacije (npr. u Program.cs).
/// Koristi se za unos demo/test podataka koji nisu dio migracije.
/// </summary>
public static class DynamicDataSeeder
{
    public static async Task SeedAsync(DatabaseContext context)
    {
        // Osiguraj da baza postoji
        await context.Database.EnsureCreatedAsync();

        await SeedProductCategoriesAsync(context);
        await SeedUsersAsync(context);
        await SeedProductsAsync(context);
        await SeedOrdersAsync(context);
    }

    private static async Task SeedProductCategoriesAsync(DatabaseContext context)
    {
        if (!await context.ProductCategories.AnyAsync())
        {
            context.ProductCategories.AddRange(
                new ProductCategoryEntity { Name = "Računari", IsEnabled = true, CreatedAtUtc = DateTime.UtcNow },
                new ProductCategoryEntity { Name = "Mobilni uređaji", IsEnabled = true, CreatedAtUtc = DateTime.UtcNow },
                new ProductCategoryEntity { Name = "Periferija", IsEnabled = true, CreatedAtUtc = DateTime.UtcNow },
                new ProductCategoryEntity { Name = "Komponente", IsEnabled = true, CreatedAtUtc = DateTime.UtcNow },
                new ProductCategoryEntity { Name = "Audio oprema", IsEnabled = false, CreatedAtUtc = DateTime.UtcNow }
            );
            await context.SaveChangesAsync();
            Console.WriteLine("✅ Dynamic seed: product categories added.");
        }
    }

    private static async Task SeedUsersAsync(DatabaseContext context)
    {
        if (await context.Users.AnyAsync())
            return;

        var hasher = new PasswordHasher<MarketUserEntity>();

        var admin = new MarketUserEntity
        {
            Email = "admin@market.local",
            PasswordHash = hasher.HashPassword(null!, "Admin123!"),
            IsAdmin = true,
            IsEnabled = true,
            CreatedAtUtc = DateTime.UtcNow
        };

        var customer1 = new MarketUserEntity
        {
            Email = "nina.bijedic@email.com",
            PasswordHash = hasher.HashPassword(null!, "Customer123!"),
            IsEnabled = true,
            CreatedAtUtc = DateTime.UtcNow.AddDays(-30)
        };

        context.Users.AddRange(admin, customer1);
        await context.SaveChangesAsync();
        Console.WriteLine("✅ Dynamic seed: demo users added.");
    }

    private static async Task SeedProductsAsync(DatabaseContext context)
    {
        if (await context.Products.AnyAsync())
            return;

        var categories = await context.ProductCategories.Where(c => c.IsEnabled).ToListAsync();
        if (!categories.Any()) return;

        var racunariCat = categories.FirstOrDefault(c => c.Name.Contains("Računari"));

        if (racunariCat != null)
        {
            context.Products.Add(new ProductEntity
            {
                Name = "Lenovo ThinkPad X1 Carbon Gen 11",
                Description = "14\" FHD+ IPS, Intel i7-1365U, 16GB RAM, 512GB SSD",
                Price = 2899.00m,
                StockQuantity = 15,
                CategoryId = racunariCat.Id,
                IsEnabled = true,
                CreatedAtUtc = DateTime.UtcNow.AddDays(-20)
            });
            await context.SaveChangesAsync();
            Console.WriteLine("✅ Dynamic seed: products added.");
        }
    }

    private static async Task SeedOrdersAsync(DatabaseContext context)
    {
        if (await context.Orders.AnyAsync())
            return;
        // Ovdje se može dodati logika za narudžbe ako je potrebna
    }

    private static OrderItemEntity CreateOrderItem(ProductEntity product, decimal quantity, decimal discountPercent)
    {
        var unitPrice = product.Price;
        var subtotal = quantity * unitPrice;
        var discountAmount = discountPercent > 0 ? Math.Round(subtotal * (discountPercent / 100), 2) : 0m;
        var total = subtotal - discountAmount;

        return new OrderItemEntity
        {
            ProductId = product.Id,
            Quantity = quantity,
            UnitPrice = unitPrice,
            Subtotal = subtotal,
            DiscountPercent = discountPercent > 0 ? discountPercent : null,
            DiscountAmount = discountAmount > 0 ? discountAmount : null,
            Total = total,
            Order = null!,
            CreatedAtUtc = DateTime.UtcNow
        };
    }
}