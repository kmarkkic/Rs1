using Market.Domain.Entities.UdomiMe;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastructure.Database.Configurations.UdomiMe;

public sealed class AnimalConfiguration : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> b)
    {
        b.ToTable("Animals");
        b.HasKey(x => x.Id);

        b.HasOne(x => x.Owner)
            .WithMany(u => u.Animals)
            .HasForeignKey(x => x.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(x => x.AnimalType)
            .WithMany(t => t.Animals)
            .HasForeignKey(x => x.AnimalTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(x => x.Breed)
            .WithMany(br => br.Animals)
            .HasForeignKey(x => x.BreedId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(x => x.City)
            .WithMany(c => c.Animals)
            .HasForeignKey(x => x.CityId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(x => x.Shelter)
            .WithMany(s => s.Animals)
            .HasForeignKey(x => x.ShelterId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(x => x.AnimalStatus)
            .WithMany(s => s.Animals)
            .HasForeignKey(x => x.AnimalStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}