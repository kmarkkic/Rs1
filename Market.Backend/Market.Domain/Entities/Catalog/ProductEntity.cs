using Market.Domain.Common;
using Market.Domain.Entities.Identity;
using Market.Domain.Entities.Sales;

namespace Market.Domain.Entities.Catalog;

/// <summary>
/// Represents a product in the system.
/// </summary>
public class ProductEntity : BaseEntity // Zivotinja
{

    // ime zivotinje
    public string Name { get; set; }

    // ID vlasnika zivotinje
    public int OwnerId { get; set; }

    // Referenca na vlasnika zivotinje
    public MarketUserEntity? Owner { get; set; }

    // Opis zivotinje
    public string? Description { get; set; }

    // Je li zivotinja vakcinisana
    public bool isVaccinated { get; set; }

    // Je li zivotinja udomljena

    public bool isAdopted { get; set; }

    // Je li zivotinja sterlizisana

    public  bool isSterilized { get; set; } 


    // Starost zivotinje
    public int Age { get; set; }

    /// <summary>
    /// Spol zivotinje (npr. "M" za mužjak, "F" za ženka, "U" za nepoznato).
    /// </summary>
    public string Gender { get; set; }

    

    /// <summary>
    /// Tip zivotinje .
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Navigacija za zivotinjin tip.
    /// </summary>
    public ProductCategoryEntity? Category { get; set; }

    /// <summary>
    /// IsEnabled
    /// </summary>
    public bool IsEnabled { get; set; }


    // Many-to-many: Users who favorited this product
    public ICollection<UserProductFavoriteEntity> FavoritedByUsers { get; private set; } = new List<UserProductFavoriteEntity>();


    ///// <summary>
    ///// Collection of order items.
    /////
    ///// **Napomena za studente:**

    ///// </summary>
    //public IReadOnlyCollection<OrderItemEntity> Items { get; set; } = new List<OrderItemEntity>();


    /// <summary>
    /// Single source of truth for technical/business constraints.
    /// Used in validators and EF configuration.
    /// </summary>
    public static class Constraints
    {
        public const int NameMaxLength = 150;

        public const int DescriptionMaxLength = 1000;
    }
}