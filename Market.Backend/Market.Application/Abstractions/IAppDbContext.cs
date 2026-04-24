using Market.Domain.Entities.Sales;
using Market.Domain.Entities.UdomiMe;
using Market.Domain.Entities.Identity; // Ovo će ti vjerojatno trebati za MarketUserEntity
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Abstractions;

public interface IAppDbContext
{
    // Identitet i bazične stvari
    DbSet<MarketUserEntity> Users { get; }
    DbSet<RefreshTokenEntity> RefreshTokens { get; }

    // Prodaja (Sales)
    DbSet<ProductEntity> Products { get; }
    DbSet<ProductCategoryEntity> ProductCategories { get; }
    DbSet<OrderEntity> Orders { get; }
    DbSet<OrderItemEntity> OrderItems { get; }

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