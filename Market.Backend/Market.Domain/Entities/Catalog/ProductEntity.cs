using Market.Domain.Common;
using Market.Domain.Entities.Identity;
using Market.Domain.Entities.Sales;

namespace Market.Domain.Entities.Catalog;

public class ProductEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    // --- OVO SU POLJA KOJA TI FALE ZA BUILD ---
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    // ------------------------------------------

    public int CategoryId { get; set; }
    public ProductCategoryEntity? Category { get; set; }

    public bool IsEnabled { get; set; }

    // Polja za "životinja" logiku (ako vam je to ipak dio proizvoda)
    public bool isVaccinated { get; set; }
    public bool isAdopted { get; set; }
    public bool isSterilized { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; } = "U";

    // Veze
    public ICollection<UserProductFavoriteEntity> FavoritedByUsers { get; private set; } = new List<UserProductFavoriteEntity>();

    public static class Constraints
    {
        public const int NameMaxLength = 150;
        public const int DescriptionMaxLength = 1000;
    }
}