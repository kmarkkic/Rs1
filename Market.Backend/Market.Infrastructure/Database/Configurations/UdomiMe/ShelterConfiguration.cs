using Market.Domain.Entities.UdomiMe;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastructure.Database.Configurations.UdomiMe;

public sealed class ShelterConfiguration : IEntityTypeConfiguration<Shelter>
{
    public void Configure(EntityTypeBuilder<Shelter> b)
    {
        b.ToTable("Shelters");
        b.HasKey(x => x.Id);
        b.HasOne(x => x.City)
            .WithMany(c => c.Shelters)
            .HasForeignKey(x => x.CityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}