using Market.Domain.Entities.Identity;
using Market.Domain.Entities.UdomiMe;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Abstractions;

public interface IAppDbContext
{
    // Identitet
    DbSet<MarketUserEntity> Users { get; }
    DbSet<RefreshTokenEntity> RefreshTokens { get; }

    // Udomljavanje (UdomiMe)
    DbSet<Animal> Animals { get; }
    DbSet<AnimalStatus> AnimalStatuses { get; }
    DbSet<AnimalType> AnimalTypes { get; }
    DbSet<Breed> Breeds { get; }
    DbSet<AnimalImage> AnimalImages { get; }
    DbSet<AdoptionRequest> AdoptionRequests { get; }
    DbSet<AdoptionRequestStatus> AdoptionRequestStatuses { get; }
    DbSet<City> Cities { get; }
    DbSet<Shelter> Shelters { get; }
    DbSet<VisitRequest> VisitRequests { get; }
    DbSet<Favourite> Favourites { get; }

    Task<int> SaveChangesAsync(CancellationToken ct);
}