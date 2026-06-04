using Market.Domain.Entities.UdomiMe;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastructure.Database.Configurations
{
    public class AnimalHealthRecordConfiguration : IEntityTypeConfiguration<AnimalHealthRecord>
    {
        public void Configure(EntityTypeBuilder<AnimalHealthRecord> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.VetName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Date).IsRequired();

            builder.HasOne(x => x.Animal)
                   .WithMany(x => x.HealthRecords)
                   .HasForeignKey(x => x.AnimalId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}