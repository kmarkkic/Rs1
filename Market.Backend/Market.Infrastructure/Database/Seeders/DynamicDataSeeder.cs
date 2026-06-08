using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Market.Domain.Entities.Identity;
using Market.Domain.Entities.UdomiMe;

namespace Market.Infrastructure.Database.Seeders;

public static class DynamicDataSeeder
{
    public static async Task SeedAsync(DatabaseContext context)
    {
        await context.Database.MigrateAsync();

        await SeedUsersAsync(context);
        await SeedAnimalsAsync(context);
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

    private static async Task SeedAnimalsAsync(DatabaseContext context)
    {
        if (await context.Animals.AnyAsync())
            return;

        // AnimalType
        var pas = new AnimalType { Name = "Pas" };
        var macka = new AnimalType { Name = "Mačka" };
        var ostalo = new AnimalType { Name = "Ostalo" };
        context.AnimalTypes.AddRange(pas, macka, ostalo);
        await context.SaveChangesAsync();

        // Breed
        var labrador = new Breed { Name = "Labrador", AnimalTypeId = pas.Id };
        var nemacki = new Breed { Name = "Njemački ovčar", AnimalTypeId = pas.Id };
        var sijamska = new Breed { Name = "Sijamska", AnimalTypeId = macka.Id };
        var perzijska = new Breed { Name = "Perzijska", AnimalTypeId = macka.Id };
        context.Breeds.AddRange(labrador, nemacki, sijamska, perzijska);
        await context.SaveChangesAsync();

        // City
        var mostar = new City { Name = "Mostar" };
        var sarajevo = new City { Name = "Sarajevo" };
        var banjaLuka = new City { Name = "Banja Luka" };
        context.Cities.AddRange(mostar, sarajevo, banjaLuka);
        await context.SaveChangesAsync();

        // Shelter
        var shelter1 = new Shelter
        {
            Name = "Sklonište Mostar",
            Address = "Bišće Polje bb",
            PhoneNumber = "036111222",
            Email = "mostar@udomime.local",
            CityId = mostar.Id
        };

        var shelter2 = new Shelter
        {
            Name = "Sklonište Sarajevo",
            Address = "Reljevo bb",
            PhoneNumber = "033333444",
            Email = "sarajevo@udomime.local",
            CityId = sarajevo.Id
        };

        var shelter3 = new Shelter
        {
            Name = "Sklonište Banja Luka",
            Address = "Rakovačke bare bb",
            PhoneNumber = "051555666",
            Email = "banjaluka@udomime.local",
            CityId = banjaLuka.Id
        };

        context.Shelters.AddRange(shelter1, shelter2, shelter3);
        await context.SaveChangesAsync();

        // AnimalStatus
        var available = new AnimalStatus { Name = "Dostupno" };
        var adopted = new AnimalStatus { Name = "Usvojen" };
        var pending = new AnimalStatus { Name = "Na čekanju" };
        context.AnimalStatuses.AddRange(available, adopted, pending);
        await context.SaveChangesAsync();

        // Password Hasher za obične korisnike
        var hasher = new PasswordHasher<MarketUserEntity>();

        // Kreiranje korisnika
        var user1 = new MarketUserEntity
        {
            FirstName = "Marko",
            LastName = "Marković",
            Email = "user1@udomime.local",
            PasswordHash = hasher.HashPassword(null!, "User123!"),
            PhoneNumber = "061111222",
            CityId = mostar.Id,
            IsEnabled = true,
            CreatedAtUtc = DateTime.UtcNow
        };

        var user2 = new MarketUserEntity
        {
            FirstName = "Ana",
            LastName = "Anić",
            Email = "user2@udomime.local",
            PasswordHash = hasher.HashPassword(null!, "User123!"),
            PhoneNumber = "062222333",
            CityId = sarajevo.Id,
            IsEnabled = true,
            CreatedAtUtc = DateTime.UtcNow
        };

        var user3 = new MarketUserEntity
        {
            FirstName = "Jovan",
            LastName = "Jovanović",
            Email = "user3@udomime.local",
            PasswordHash = hasher.HashPassword(null!, "User123!"),
            PhoneNumber = "065333444",
            CityId = banjaLuka.Id,
            IsEnabled = true,
            CreatedAtUtc = DateTime.UtcNow
        };

        context.Users.AddRange(user1, user2, user3);
        await context.SaveChangesAsync();

        // Animal
        var animal1 = new Animal
        {
            Name = "Rex",
            Age = 3,
            Description = "Prijateljski pas koji voli djecu i igru.",
            Gender = "Mužjak",
            IsVaccinated = true,
            IsSterilized = true,
            OwnerId = user1.Id,
            AnimalTypeId = pas.Id,
            BreedId = labrador.Id,
            CityId = mostar.Id,
            ShelterId = shelter1.Id,
            AnimalStatusId = available.Id
        };

        var animal2 = new Animal
        {
            Name = "Luna",
            Age = 2,
            Description = "Mirna i umiljata mačka koja voli pažnju.",
            Gender = "Ženka",
            IsVaccinated = true,
            IsSterilized = true,
            OwnerId = user2.Id,
            AnimalTypeId = macka.Id,
            BreedId = sijamska.Id,
            CityId = sarajevo.Id,
            ShelterId = shelter2.Id,
            AnimalStatusId = available.Id
        };

        var animal3 = new Animal
        {
            Name = "Max",
            Age = 5,
            Description = "Pametan i zaštitnički pas, naviknut na ljude.",
            Gender = "Mužjak",
            IsVaccinated = true,
            IsSterilized = false,
            OwnerId = user3.Id,
            AnimalTypeId = pas.Id,
            BreedId = nemacki.Id,
            CityId = banjaLuka.Id,
            ShelterId = shelter3.Id,
            AnimalStatusId = pending.Id
        };

        var animal4 = new Animal
        {
            Name = "Mia",
            Age = 4,
            Description = "Tiha perzijska mačka koja voli mirno okruženje.",
            Gender = "Ženka",
            IsVaccinated = true,
            IsSterilized = true,
            OwnerId = user3.Id,
            AnimalTypeId = macka.Id,
            BreedId = perzijska.Id,
            CityId = mostar.Id,
            ShelterId = shelter1.Id,
            AnimalStatusId = adopted.Id
        };

        var animal5 = new Animal
        {
            Name = "Bobi",
            Age = 1,
            Description = "Mlad i razigran pas koji traži aktivnog vlasnika.",
            Gender = "Mužjak",
            IsVaccinated = false,
            IsSterilized = false,
            OwnerId = user1.Id,
            AnimalTypeId = pas.Id,
            BreedId = labrador.Id,
            CityId = sarajevo.Id,
            ShelterId = shelter2.Id,
            AnimalStatusId = available.Id
        };

        context.Animals.AddRange(animal1, animal2, animal3, animal4, animal5);
        await context.SaveChangesAsync();

        Console.WriteLine("✅ Dynamic seed: animals added.");
    }
}