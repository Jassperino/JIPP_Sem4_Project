using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JIPP_Projekt_Sem4.Models.Configurations;

public class CryptocurrencyConfiguration : IEntityTypeConfiguration<Cryptocurrency>
{
    public void Configure(EntityTypeBuilder<Cryptocurrency> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.User)
            .WithOne(u => u.Cryptocurrency)
            .HasForeignKey<Cryptocurrency>(x => x.UserId);
        builder.Property(x => x.Bitcoin).HasColumnType("decimal(18,2)");
        builder.Property(x => x.Ethereum).HasColumnType("decimal(18,2)");
        builder.Property(x => x.Tether).HasColumnType("decimal(18,2)");
        builder.Property(x => x.ZCash).HasColumnType("decimal(18,2)");
    }
}