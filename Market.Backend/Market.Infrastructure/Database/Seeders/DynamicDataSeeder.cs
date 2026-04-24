using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Market.Domain.Entities.Identity;
using Market.Domain.Entities.UdomiMe;

namespace Market.Infrastructure.Database.Seeders;

public static class DynamicDataSeeder
{
    public static async Task SeedAsync(DatabaseContext context)
    {
        await context.Database.EnsureCreatedAsync();

        await SeedUsersAsync(context);
        // Ovdje kasnije možeš dodati SeedAnimalsAsync(context); kad napraviš tu metodu
    }

    private static async Task SeedUsersAsync(DatabaseContext context)
    {
        if (await context.Users.AnyAsync())
            return;

        var hasher = new PasswordHasher<MarketUserEntity>();

        var admin = new MarketUserEntity
        {
            Email = "admin@udomime.local",
            PasswordHash = hasher.HashPassword(null!, "Admin123!"),
            IsAdmin = true,
            IsEnabled = true,
            CreatedAtUtc = DateTime.UtcNow
        };

        context.Users.Add(admin);
        await context.SaveChangesAsync();
        Console.WriteLine("✅ Dynamic seed: admin user added.");
    }
}