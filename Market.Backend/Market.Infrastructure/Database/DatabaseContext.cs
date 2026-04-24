using Market.Application.Abstractions;
using Market.Domain.Entities.Identity;
using Market.Domain.Entities.UdomiMe;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Database;

public partial class DatabaseContext : DbContext, IAppDbContext
{
    private readonly TimeProvider _clock;

    public DatabaseContext(DbContextOptions<DatabaseContext> options, TimeProvider clock) : base(options)
    {
        _clock = clock;
    }

    public DbSet<MarketUserEntity> Users => Set<MarketUserEntity>();
    public DbSet<RefreshTokenEntity> RefreshTokens => Set<RefreshTokenEntity>();
    public DbSet<Animal> Animals => Set<Animal>();
    public DbSet<AnimalStatus> AnimalStatuses => Set<AnimalStatus>();
    public DbSet<AnimalType> AnimalTypes => Set<AnimalType>();
    public DbSet<Breed> Breeds => Set<Breed>();
    public DbSet<AnimalImage> AnimalImages => Set<AnimalImage>();
    public DbSet<AdoptionRequest> AdoptionRequests => Set<AdoptionRequest>();
    public DbSet<AdoptionRequestStatus> AdoptionRequestStatuses => Set<AdoptionRequestStatus>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<Shelter> Shelters => Set<Shelter>();
    public DbSet<VisitRequest> VisitRequests => Set<VisitRequest>();
    public DbSet<Favourite> Favourites => Set<Favourite>();
}