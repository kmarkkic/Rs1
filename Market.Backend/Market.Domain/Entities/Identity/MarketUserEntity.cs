using Market.Domain.Common;
using Market.Domain.Entities.UdomiMe;

namespace Market.Domain.Entities.Identity;

public sealed class MarketUserEntity : BaseEntity
{
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public bool IsAdmin { get; set; }
    public bool IsManager { get; set; }
    public bool IsEmployee { get; set; }
    public int TokenVersion { get; set; } = 0;
    public bool IsEnabled { get; set; }

    public ICollection<RefreshTokenEntity> RefreshTokens { get; private set; } = new List<RefreshTokenEntity>();

    // Sekcija za UdomiMe - SVE OSTALO ŠTO NIJE UDOMIME JE IZBRISANO
    public ICollection<Favourite> Favorites { get; set; } = new List<Favourite>();
    public ICollection<Animal> Animals { get; set; } = new List<Animal>();
    public ICollection<AdoptionRequest> AdoptionRequests { get; set; } = new List<AdoptionRequest>();
    public ICollection<VisitRequest> VisitRequests { get; set; } = new List<VisitRequest>();
}