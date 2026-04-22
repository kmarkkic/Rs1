<<<<<<< HEAD
﻿using Market.Domain.Entities.Sales;
=======
﻿using Market.Domain.Entities.UdomiMe;
>>>>>>> 74087fd (Initial commit)

namespace Market.Application.Abstractions;

// Application layer
public interface IAppDbContext
{
<<<<<<< HEAD
    DbSet<ProductEntity> Products { get; }
    DbSet<ProductCategoryEntity> ProductCategories { get; }
    DbSet<MarketUserEntity> Users { get; }
    DbSet<RefreshTokenEntity> RefreshTokens { get; }

    DbSet<OrderEntity> Orders{ get; }
    DbSet<OrderItemEntity> OrderItems { get; }
=======


    DbSet<MarketUserEntity> Users { get; }
    DbSet<RefreshTokenEntity> RefreshTokens { get; }
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
>>>>>>> 74087fd (Initial commit)

    Task<int> SaveChangesAsync(CancellationToken ct);
}