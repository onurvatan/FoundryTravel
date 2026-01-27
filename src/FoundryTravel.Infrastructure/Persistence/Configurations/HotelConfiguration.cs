using FoundryTravel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoundryTravel.Infrastructure.Persistence.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(h => h.Name).IsRequired().HasMaxLength(200);
        builder.Property(h => h.Description).IsRequired();
        builder.Property(h => h.Address).IsRequired().HasMaxLength(300);

        builder.HasOne<City>()
            .WithMany()
            .HasForeignKey(h => h.CityId);
    }
}