using Market.Domain.Entities.UdomiMe;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastructure.Database.Configurations.UdomiMe;

public sealed class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> b)
    {
        b.ToTable("Breeds");
        b.HasKey(x => x.Id);
        b.HasOne(x => x.AnimalType)
            .WithMany(t => t.Breeds)
            .HasForeignKey(x => x.AnimalTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}