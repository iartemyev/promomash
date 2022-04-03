using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoMash.Domain.Core;

namespace PromoMash.Persistence.EntityTypeConfiguration;

public class ProvinceConfiguration : IEntityTypeConfiguration<ProvinceEntity>
{
    public void Configure(EntityTypeBuilder<ProvinceEntity> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.Id).IsUnique();
        builder.HasIndex(p => p.Id).IsUnique();
        builder.Property(p => p.Name).HasMaxLength(250);
    }
}