using Market.Application.Abstractions;
using Market.Domain.Entities.Sales;

namespace Market.Infrastructure.Database;

public partial class DatabaseContext : DbContext, IAppDbContext
{
    public DbSet<ProductCategoryEntity> ProductCategories => Set<ProductCategoryEntity>();
    public DbSet<ProductEntity> Products => Set<ProductEntity>();
    public DbSet<MarketUserEntity> Users => Set<MarketUserEntity>();
    public DbSet<RefreshTokenEntity> RefreshTokens => Set<RefreshTokenEntity>();

    public DbSet<OrderEntity> Orders => Set<OrderEntity>();
    public DbSet<OrderItemEntity> OrderItems => Set<OrderItemEntity>();

    private readonly TimeProvider _clock;


    public DbSet<Market.Domain.Entities.UdomiMe.Animal> Animals => Set<Market.Domain.Entities.UdomiMe.Animal>();
    public DbSet<Market.Domain.Entities.UdomiMe.AnimalStatus> AnimalStatuses => Set<Market.Domain.Entities.UdomiMe.AnimalStatus>();
    public DbSet<Market.Domain.Entities.UdomiMe.AnimalType> AnimalTypes => Set<Market.Domain.Entities.UdomiMe.AnimalType>();
    public DbSet<Market.Domain.Entities.UdomiMe.Breed> Breeds => Set<Market.Domain.Entities.UdomiMe.Breed>();
    public DbSet<Market.Domain.Entities.UdomiMe.AnimalImage> AnimalImages => Set<Market.Domain.Entities.UdomiMe.AnimalImage>();
    public DbSet<Market.Domain.Entities.UdomiMe.AdoptionRequest> AdoptionRequests => Set<Market.Domain.Entities.UdomiMe.AdoptionRequest>();
    public DbSet<Market.Domain.Entities.UdomiMe.AdoptionRequestStatus> AdoptionRequestStatuses => Set<Market.Domain.Entities.UdomiMe.AdoptionRequestStatus>();
    public DbSet <Market.Domain.Entities.UdomiMe.City> Cities => Set<Market.Domain.Entities.UdomiMe.City>();    
    public DbSet<Market.Domain.Entities.UdomiMe.Shelter> Shelters => Set<Market.Domain.Entities.UdomiMe.Shelter>();
    public DbSet <Market.Domain.Entities.UdomiMe.VisitRequest> VisitRequests => Set<Market.Domain.Entities.UdomiMe.VisitRequest>(); 
    public DbSet<Market.Domain.Entities.UdomiMe.Favourite> Favourites => Set<Market.Domain.Entities.UdomiMe.Favourite>();
    public DbSet<Market.Domain.Entities.UdomiMe.User> UsersUdomiMe => Set<Market.Domain.Entities.UdomiMe.User>();
    

    public DatabaseContext(DbContextOptions<DatabaseContext> options, TimeProvider clock) : base(options)
    {
        _clock = clock;
    }


}